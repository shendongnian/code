    var eventResults = new[]
    {
        new EventItem(1, "StoryTime", new DateTime(2018, 4, 6), new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0)),
        new EventItem(2, "Baking", new DateTime(2018, 4, 6), new TimeSpan(8,55, 0), new TimeSpan(9, 30, 0)),
        new EventItem(3, "Cooking", new DateTime(2018, 4, 7), new TimeSpan(7,45, 0), new TimeSpan(9, 50, 0)),
        new EventItem(4, "Comprehension", new DateTime(2018, 4, 8), new TimeSpan(9, 5, 0), new TimeSpan(10,10, 0)),
        new EventItem(5, "WindDown", new DateTime(2018, 4, 8), new TimeSpan(10,25, 0), new TimeSpan(10,55, 0)),
        new EventItem(6, "Naptime", new DateTime(2018, 4, 8), new TimeSpan(11,0, 0), new TimeSpan(11,30, 0)),
        new EventItem(7, "Play", new DateTime(2018, 4, 8), new TimeSpan(13,50,0), new TimeSpan(14,20, 0)),
        new EventItem(8, "Smarts", new DateTime(2018, 4, 8), new TimeSpan(14,30,0), new TimeSpan(16, 0, 0)),
        new EventItem(9, "StoryTime", new DateTime(2018, 4, 9), new TimeSpan(9,30, 0), new TimeSpan(12, 5, 0)),
        new EventItem(10, "FunTime", new DateTime(2018, 4, 10), new TimeSpan(14,10,0), new TimeSpan(16,10, 0)),
    };
    var groups = eventResults
        .GroupBy(x => x.EventDate)
        .SelectMany(g => g.OrderBy(x => x.EventStart)
            .Aggregate(new List<List<EventItem>> { new List<EventItem>() }, (l, e) =>
            {
                if ((e.EventStart - l.Last().Select(x => x.EventEnd).DefaultIfEmpty(e.EventStart).Last()).TotalMinutes <= 30)
                {
                    l.Last().Add(e);
                }
                else
                {
                    l.Add(new List<EventItem> { e });
                }
                return l;
            })
            .Select(x =>
            new
            {
                Date = g.Key,
                activities = x
            }))
        .OrderBy(x => x.Date).ThenBy(x => x.activities.First().EventStart);
    foreach (var item in groups)
    {
        var activities = string.Join(" + ", item.activities.Select(x => x.EventName));
        Console.WriteLine($"On {item.Date}, {activities}: {item.activities.First().EventStart} - {item.activities.Last().EventEnd}");
    }
