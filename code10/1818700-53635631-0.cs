        string a = "11:50-12:30";
        Stopwatch watch = new Stopwatch();
        watch.Start();
        DateTime start = DateTime.Today.Add(DateTime.ParseExact(a.Split('-').First(), "hh:mm", CultureInfo.InvariantCulture).TimeOfDay);
        DateTime end = DateTime.Today.Add(DateTime.ParseExact(a.Split('-').Last(), "hh:mm", CultureInfo.InvariantCulture).TimeOfDay);
        watch.Stop();
        Console.WriteLine(watch.Elapsed.ToString());
        Console.WriteLine(start.ToString());
        Console.WriteLine(end.ToString());
