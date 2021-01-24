    int indexOfLastMonthName = Array.IndexOf(monthNames, lastMonthName);
    
    var parentData = Enumerable
      // Create as many items as last month number
      .Range(0, lastMonthNumber)
      // Create the list in reverse order, start on LastMonthName and 12,
      // then go back with every item
      .Select(x => new 
      { 
        Number = 12 - x, 
        Name = GetMonthName(indexOfLastMonthName - i)
      }
      
      // Turn it back
      .Reverse();
