    FilterExpression filter1 = new FilterExpression();
    filter1.Conditions.Add(condition1);
    
    QueryExpression query = new QueryExpression("contact");
    query.ColumnSet.AddColumns("firstname", "lastname");
    query.Criteria.AddFilter(filter1);
    
    EntityCollection result1 = _serviceProxy.RetrieveMultiple(query);
    Console.WriteLine();Console.WriteLine("Query using Query Expression with ConditionExpression and FilterExpression");
    Console.WriteLine("---------------------------------------");
    foreach (var a in result1.Entities)
    {
        Console.WriteLine("Name: " + a.Attributes["firstname"] + " " + a.Attributes["lastname"]);
    }
