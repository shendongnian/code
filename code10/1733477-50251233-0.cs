    DateTime date = DateTime.Parse("2/27/2010 1:06:49 PM");
    foreach (KeyValuePair<DateTime, List<string>> k in Sample)
    {
       //if both Ticks are same, you should expect dates to be equal
       Console.WriteLine(date.Ticks + "-" + k.Key.Ticks);
       if (date.Equals(k.Key))
       {
          Console.WriteLine("Yes");
       }
       else {
          Console.WriteLine("No");
       }
    }
