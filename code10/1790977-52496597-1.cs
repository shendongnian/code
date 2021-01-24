    int indexOfLastMonthName = monthNames.IndexOf(lastMonthName);
    
    var parentData = Enumerable
      // Create as many items as last month number (values do not matter)
      .Range(0, lastMonthNumber)
      // Create the list in reverse order, start on LastMonthName and 12,
      // then go back with every item (i is the element index starting with 0)
      .Select((x, i) => new 
      { 
        Number = 12 - i, 
        Name = GetMonthName(indexOfLastMonthName - i)
      }
      
      // Turn it back
      .Reverse();
