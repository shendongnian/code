        var tmp = unusedroles.Select(x => new { x.Username, x.Role }).Distinct();
        foreach (var item in tmp)
        {
            unusedrolesoccurrence.Add(new UnusedRolesOccurrence
            {
                //Username = item.Username, Role = item.Role, Month = dictionary_month
                Username = item.Username, Role = item.Role, Month = new int[12]
            });
        }
