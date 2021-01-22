    DateTime givenDate = DateTime.Today;
    DateTime startOfWeek = givenDate.AddDays(-1 * givenDate.DayOfWeek);
    DateTime endOfWeek = startOfWeek.AddDays(7);
    
    var query = myObjects
      .Where(ob => startOfWeek <= ob.DateField && ob.DateField < endOfWeek)
