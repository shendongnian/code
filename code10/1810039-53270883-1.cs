    var flattened = new List<Event>();
    for (int i = events.Count - 1; i > 0; i--)
    {
        events.TimeOffset = events[i].EventStart - events[i - 1].EventEnd;
    }
    foreach (var grouping in events.GroupBy(g => g.EventName))
    {
        var compressed = grouping.First();
        foreach (var ev in grouping)
        {
            if (ev.TimeOffset?.Minutes > 30 ?? false)
            {
                // In this case, we have flattened as far as we can
                // Add the event and start over
                flattened.Add(compressed);
                compressed = new Event
                {
                    Id = ev.Id,
                    EventName = ev.EventName,
                    EventDate = ev.EventDate,
                    EventStart = ev.EventStart,
                    EventEnd = ev.EventEnd
                };
            }
            else
            {
                compressed.Name = $"{compressed.Name} + {ev.Name}";
                compressed.EventEnd = ev.EventEnd;
            }
        }
    }
