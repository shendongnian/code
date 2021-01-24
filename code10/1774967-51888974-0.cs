    DateTime d1 = DateTime.UtcNow;
    DateTime d2 = DateTime.UtcNow.AddDays(1);
    TimeSpan ts = d2 - d1;
    Console.WriteLine(ts.TotalMilliseconds);
    // Outputs 86400000
