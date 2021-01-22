    var queryA = 
        from a in context.TableA
        select new 
        {
            id,
            name,
            onlyInTableA,
        }
    var queryB = 
        from b in context.TableB
        let onlyInTableA = default(string)
        select new 
        {
            id,
            name,
            onlyInTableA,
        }
    var results = queryA.Union(queryB).ToList();
