    int secondDiff = 30;
    DateTime timeUpper = DateTime.Parse("2017-04-25 14:16:30.000");
    DateTime timeLower = DateTime.Parse("2017-04-25 14:15:30.000");
    List<string> results = yourContext.TableName.AsEnumerable()
        .Where(t => t.TimeStamp.AddSeconds(secondDiff) <= timeUpper && 
            t.TimeStamp.AddSeconds(-secondDiff) >= timeLower);
        .Select(t => t.Column3).ToList();
    // Output is { 89 }
