    DateTime end = new DateTime(2018, 04, 13, 12, 17, 39, 067);
    DateTime start = new DateTime(2018, 04, 13, 12, 17, 38, 893);
    var diff = end.AddMilliseconds(-end.Millisecond) - start.AddMilliseconds(-start.Millisecond);
    string s = string.Format("{0:mm} : {0:ss}", diff);
    Console.WriteLine (s); // 00:01
