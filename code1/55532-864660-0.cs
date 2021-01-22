    // time range expressed as an example in "absolute" terms
    DateTime sd = new DateTime(2000, 1, 1, 9, 30, 0);
    DateTime ed = new DateTime(2000, 1, 2, 6, 0, 0);
    
    // time range expressed as a zero and range - "relative" terms
    TimeSpan zero = sd.TimeOfDay;
    TimeSpan range = ed.Subtract(sd);
     //the inputs
    List<DateTime> myList = new List<DateTime>()
    {
      new DateTime(2009, 1, 1, 10, 0, 0),  //group1
      new DateTime(2009, 1, 1, 17, 0, 0),  //group1
      new DateTime(2009, 1, 2, 9, 0, 0),  //this is filtered
      new DateTime(2009, 1, 2, 10, 0, 0),  //group2
      new DateTime(2009, 1, 2, 15, 0, 0),  //group2
      new DateTime(2009, 1, 3, 3, 0, 0),   //group2
      new DateTime(2009, 1, 3, 7, 0, 0),  //this is filtered
      new DateTime(2009, 1, 3, 10, 0, 0)   //group3
    };
      //at last, the query.
    var query = myList
      .Where(d => d.Subtract(zero).TimeOfDay < range)
      .GroupBy(d => d.Subtract(zero).Date);
     //  output the results
    foreach (var g in query)
    {
      Console.WriteLine("{0}", g.Count());
      foreach (var d in g)
      {
        Console.WriteLine("  {0}", d);
      }
    }
