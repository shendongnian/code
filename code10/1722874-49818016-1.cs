    DateTime end = new DateTime(2018, 04, 13, 12, 17, 39, 067);
    DateTime start = new DateTime(2018, 04, 13, 12, 17, 38, 893);
    var difference = TimeSpan.FromSeconds(Math.Ceiling((end - start).TotalMilliseconds / 1000.0));
    string s = string.Format("{0:mm}:{0:ss}", difference);
    Console.WriteLine(s);
