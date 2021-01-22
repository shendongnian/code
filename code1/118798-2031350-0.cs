    for (int i = 0; i < results.Count; ++i)
    {
        var result = (NHibernate.Examples.QuickStart.User)results[i];
        Console.WriteLine(results[i].EmailAddress); // Not Working
    }
...
