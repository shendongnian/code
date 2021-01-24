    var range = new List<Interval<int>>();
    range.Add(new Interval<int>(1, 0, 1));
    range.Add(new Interval<int>(2, 1, 2));
    range.Add(new Interval<int>(3, 2, 4));
    
    var months = 5;
    var visit = range.FirstOrDefault(x => x.InRange(months)).Visit;
