    using (var dc = new DataClasses1DataContext())
    {
        var result = dc.Users
            .AsEnumerable()     // select all users from the database and bring them back to the client
            .Select((user, index) => new   // project in the index
            {
                user.Username,
                index
            })
            .Where(user => user.Username == "sivey");    // filter for your specific record
    
        foreach (var item in result)
        {
            Console.WriteLine(string.Format("{0}:{1}", item.index, item.Username));
        }
    }
