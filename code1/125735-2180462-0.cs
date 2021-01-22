    using (var db = new dbDataContext())
    {
        var query = db.people.Select(x => x.LastName.Count());
        foreach (int x in query)
        {
            Console.WriteLine(x);
        }
    }
