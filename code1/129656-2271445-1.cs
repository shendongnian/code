     var xxxx =_connectedClientRepository
            .GetConnectedClients(new[] { "LogEntry", "LogEntry.GameFile" })
            .AsExpandable()
            .Where(predicate)
            .ToList() // execute query
            .Select(cp => cp.LogEntry); // use linq-to-objects to project the result
