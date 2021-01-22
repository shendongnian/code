    using (var context = new ormDataContext(connStr))
    {
        foreach (var election in context.Elections)
        {
            Console.WriteLine( "{0}: {1}",
                               election.Name,
                               election.Election_Status.Status );
        }
    }
