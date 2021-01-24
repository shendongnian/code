    for (int i = 1; i < Props.Count(); i++)
    {
        query = query.ThenBy(p =>
        {
            Console.WriteLine(i);
            return Props[i].GetValue(p);
        });
    }
