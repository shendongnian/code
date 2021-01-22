    List<SomeClass> myList = foos
      .Select(f => new SomeClass{ ..., CssClass=string.Empty })
      .ToList();
    if (myList.Any())
    {        
      myList.First().CssClass = "first";
      myList.Last().CssClass = "last";
      foreach(var z in myList.Skip(1).Reverse().Skip(1))
      {
        z.CssClass = "mid";
      }
    }
    
    _repeater.DataSource = myList;
