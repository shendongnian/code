    var givenDate = new DateTime(2018, 4, 1);
    int addMax = DateTime.DaysInMonth(givenDate.Year, givenDate.Month) - givenDate.Day;
    int add = Math.Min(addMax, ((DayOfWeek.Saturday - givenDate.DayOfWeek) + 1) % 7);
    int subMax = givenDate.Day - 1;
    int sub = Math.Min(subMax, (givenDate.DayOfWeek - DayOfWeek.Monday + 7) % 7);
    var firstDate = givenDate.AddDays(-sub);
    var lastDate = givenDate.AddDays(add);
    Console.Write("Give: {0}({1})\nFirst: {2}({3})\nLast: {4}({5})", 
        givenDate, givenDate.DayOfWeek, 
        firstDate, firstDate.DayOfWeek, 
        lastDate, lastDate.DayOfWeek);
