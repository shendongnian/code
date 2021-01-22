    var groupings =
        from agency in agencies
        from businessUnit in agency.BusinessUnits
        from client in businessUnit.Clients
        group client by new { businessUnit.ID, businessUnit.Name } into clients
        select clients;
    var businessUnits =
        from grouping in groupings
        select new
        {
            ID = grouping.Key.ID,
            Name = grouping.Key.Name,
            AmountSpent = grouping.Sum(client => client.AmountSpent),
            Clients = grouping
        };
