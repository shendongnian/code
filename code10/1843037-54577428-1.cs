    List<TimeTest> times = new List<TimeTest>();
    //... Fill list
    if(times.Count == 0) return;
    int min = Int32.MaxValue;
    int max = Int32.MinValue;
    foreach(var item in times)
    {
        min = Math.Min(item.Start.Hour, min);
        max = Math.Max(item.End.Hour, max);
    }
