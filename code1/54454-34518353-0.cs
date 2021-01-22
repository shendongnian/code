    from grouping in list.GroupBy(x => new Tuple<string,string,string>(x.Person.LastName,x.Person.FirstName,x.Person.MiddleName))
    select new SummaryItem
    {
        LastName = grouping.Key.Item1,
        FirstName = grouping.Key.Item2,
        MiddleName = grouping.Key.Item3,
        DayCount = grouping.Count(), 
        AmountBilled = grouping.Sum(x => x.Rate),
    }
