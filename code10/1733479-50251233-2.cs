    DateTime date = DateTime.Parse("2/27/2010 1:06:49 PM");
    foreach (KeyValuePair<DateTime, List<string>> k in Sample)
    {
       if (date.Ticks == k.Key.Ticks)
       {
          Console.WriteLine("Yes");
       }
       else {
          Console.WriteLine("No");
       }
    }
