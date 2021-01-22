    var output = new List<Range>();
    var currentFrom = list[0].From;
    var currentTo = list[0].To;
    var currentCategory = list[0].Category;
    foreach (var item in list.Skip(1))
    {
        if (item.Category == currentCategory && item.From == currentTo + 1)
            currentTo = item.To;
        else
        {
            output.Add(new Range { From = currentFrom, To = currentTo,
                Category = currentCategory });
            currentFrom = item.From;
            currentTo = item.To;
            currentCategory = item.Category;
        }
    }
    output.Add(new Range { From = currentFrom, To = currentTo,
        Category = currentCategory });
