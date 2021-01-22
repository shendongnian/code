    using (var dc = new DataClasses1DataContext())
    {
        var result = dc.Users
            .Select(u => u)     // selecxt all users from the database
            .AsEnumerable()     // bring them back to the client
            .Select((u, i) => new   // project in the index
            {
                u.Username,
                i
            })
            .Where(u => u.Username == "iveys1");    // filter for your specific record
    
        foreach (var item in result)
        {
            Console.WriteLine(string.Format("{0}:{1}", item.i, item.Username));
        }
    }
