    var entities = new List<CustomEntity>();
    foreach (CustomEntity c in table.ExecuteQuerySegmented(query, continuationToken))
    {
        c.Data = 100;
        ......
        entities.Add(c);
    }
