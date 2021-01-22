    var groupings =
        from agency in agencies
        from businessUnit in agency.BusinessUnits
        from client in businessUnit.Clients
        group client by businessUnit.ID into clients
        select clients;
    var businessUnits =
        from grouping in groupings
        select new {
            ID = grouping.Key,
            AmountSpent = grouping.Sum(client => client.AmountSpent),
            Clients = grouping
        };
    foreach (var businessUnit in businessUnits) {
        Console.WriteLine("++BusinessUnit{0} - ${1}",
                          businessUnit.ID,
                          businessUnit.AmountSpent);
        foreach (var client in businessUnit.Clients) {
            Console.WriteLine("++++Client{0} - ${1}", client.ID, client.AmountSpent);
        }
    }
