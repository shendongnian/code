    List<string> rawLines1 = new List<string>() { "5/30/2018 2:48:57 PM", "06.01.2018 06:12:19" };
    List<string> rawLines2 = new List<string>() { "20180601 16:21:50" };
    List<string> rawLines = new List<string>();
    rawLines.AddRange(rawLines1);
    rawLines.AddRange(rawLines2);
    
    List<DateTime> parsedDateTimes = new List<DateTime>();
    foreach (string rawLine in rawLines) {
        parsedDateTimes.Add(ParseDateTime(rawLine));
    }
    parsedDateTimes = parsedDateTimes.OrderBy(x => x).ToList();
