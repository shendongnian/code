    DateTime start = DateTime.Now.Date.AddDays(-60);
    DateTime end = DateTime.Now.Date.AddDays(+60);
    for (DateTime current = start; current < end; current = current.AddDays(1))
    {
      Console.WriteLine("{0} --> {1}",
         current.ToShortDateString(), GetDateDescription(current));
    }
