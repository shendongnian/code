    using (var context = new ormDataContext(connStr))
    {
        var query = context.Elections
                           .Where( e => e.Election_Status.Status == someStatus );
        foreach (var election in query)
        {
            Console.WriteLine( "{0}: {1}",
                               election.Name,
                               election.Election_Status.Status );
        }
    }
