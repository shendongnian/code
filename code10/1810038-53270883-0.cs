    var flattened = new List<Event>();
    for (int i = events.Count - 1; i > 0; i--)
    {
        events.TimeOffset = events[i].EventStart - events[i - 1].EventEnd;
    }
    foreach (var grouping in events.GroupBy(g => g.EventName))
    {
        var compressed = grouping.First();
        foreach (var event in grouping)
        {
            if (event.TimeOffset?.Minutes > 30 ?? false)
            {
                // In this case, we have flattened as far as we can
                // Add the event and start over
                flattened.Add(compressed);
                compressed = new Event
                {
                    Id = event.Id,
                    EventName = event.EventName,
                    EventDate = event.EventDate,
                    EventStart = event.EventStart,
                    EventEnd = event.EventEnd
                };
            }
            else
            {
                compressed.Name = $"{compressed.Name} + {event.Name}";
                compressed.EventEnd = event.EventEnd;
            }
        }
    }
