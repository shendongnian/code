    for (int i = 1; i < Props.Count(); i++)
    {
        //.ThenBy is lacy and will not execute here - and because of that the current value of i is irrelevant
        query = query.ThenBy(p =>
        {
            Console.WriteLine(i);
            return Props[i].GetValue(p);
        });
    }
    return Ok( query.ToList() ); //the .ToList() will NOW trigger the query and execute the .ThenBys with i = Props.Count()
