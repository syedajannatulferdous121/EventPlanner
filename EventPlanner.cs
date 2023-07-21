using System;
using System.Collections.Generic;

// Event class to represent an event
class Event
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public List<string> Guests { get; set; }
    // Add more properties for advanced features
}

// EventPlanner class to manage events
class EventPlanner
{
    private List<Event> events;

    public EventPlanner()
    {
        events = new List<Event>();
    }

    // Method to create a new event
    public void CreateEvent(string title, DateTime date, string location, string description)
    {
        Event newEvent = new Event
        {
            Title = title,
            Date = date,
            Location = location,
            Description = description,
            Guests = new List<string>()
        };

        events.Add(newEvent);
        Console.WriteLine($"Event '{title}' created successfully.");
    }

    // Method to invite guests to an event
    public void InviteGuest(string eventTitle, string guestName)
    {
        Event selectedEvent = events.Find(e => e.Title == eventTitle);
        if (selectedEvent != null)
        {
            selectedEvent.Guests.Add(guestName);
            Console.WriteLine($"Invited '{guestName}' to '{eventTitle}'.");
        }
        else
        {
            Console.WriteLine($"Event '{eventTitle}' not found.");
        }
    }

    // Method to display event details
    public void ViewEvent(string eventTitle)
    {
        Event selectedEvent = events.Find(e => e.Title == eventTitle);
        if (selectedEvent != null)
        {
            Console.WriteLine($"Title: {selectedEvent.Title}");
            Console.WriteLine($"Date: {selectedEvent.Date}");
            Console.WriteLine($"Location: {selectedEvent.Location}");
            Console.WriteLine($"Description: {selectedEvent.Description}");
            Console.WriteLine($"Guests: {string.Join(", ", selectedEvent.Guests)}");
            // Display other properties as needed
        }
        else
        {
            Console.WriteLine($"Event '{eventTitle}' not found.");
        }
    }

    // Method to list all events
    public void ListEvents()
    {
        if (events.Count > 0)
        {
            Console.WriteLine("All Events:");
            foreach (var e in events)
            {
                Console.WriteLine($"Title: {e.Title}, Date: {e.Date}, Location: {e.Location}");
            }
        }
        else
        {
            Console.WriteLine("No events available.");
        }
    }

    // Method to remove a guest from an event
    public void RemoveGuest(string eventTitle, string guestName)
    {
        Event selectedEvent = events.Find(e => e.Title == eventTitle);
        if (selectedEvent != null)
        {
            if (selectedEvent.Guests.Remove(guestName))
            {
                Console.WriteLine($"Removed '{guestName}' from '{eventTitle}'.");
            }
            else
            {
                Console.WriteLine($"Guest '{guestName}' not found in '{eventTitle}'.");
            }
        }
        else
        {
            Console.WriteLine($"Event '{eventTitle}' not found.");
        }
    }
}

// Main program
class Program
{
    static void Main()
    {
        EventPlanner eventPlanner = new EventPlanner();

        // Interactive Console: Get user input and perform actions
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create an event");
            Console.WriteLine("2. Invite a guest to an event");
            Console.WriteLine("3. View event details");
            Console.WriteLine("4. List all events");
            Console.WriteLine("5. Remove guest from an event");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter event title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter event date (YYYY-MM-DD): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter event location: ");
                    string location = Console.ReadLine();
                    Console.Write("Enter event description: ");
                    string description = Console.ReadLine();
                    eventPlanner.CreateEvent(title, date, location, description);
                    break;

                case "2":
                    Console.Write("Enter event title: ");
                    string eventTitle = Console.ReadLine();
                    Console.Write("Enter guest name: ");
                    string guestName = Console.ReadLine();
                    eventPlanner.InviteGuest(eventTitle, guestName);
                    break;

                case "3":
                    Console.Write("Enter event title to view details: ");
                    eventTitle = Console.ReadLine();
                    eventPlanner.ViewEvent(eventTitle);
                    break;

                case "4":
                    eventPlanner.ListEvents();
                    break;

                case "5":
                    Console.Write("Enter event title: ");
                    eventTitle = Console.ReadLine();
                    Console.Write("Enter guest name to remove: ");
                    guestName = Console.ReadLine();
                    eventPlanner.RemoveGuest(eventTitle, guestName);
                    break;

                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
