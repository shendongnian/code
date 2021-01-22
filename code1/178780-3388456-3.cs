    DateTime[] col = { new DateTime(2010, 1, 1),
                       new DateTime(2010, 1, 2),
                       new DateTime(2010, 1, 3),
                       new DateTime(2010, 1, 5)};
    var start = new DateTime(2010, 1, 1);
    var end = new DateTime(2010, 1, 6);
    var range = Enumerable.Range(0, (int)(end - start).TotalDays + 1)
                          .Select(i => start.AddDays(i));
    var missing = range.Except(col);
