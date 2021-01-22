    string objectType = "MyProperty";
    using (MyEntitiesContext entitiesContext = new MyEntitiesContext())
    {
    try
    {
        string queryString = @"SELECT VALUE " + objectType+  " FROM MyEntitiesContext." + objectType + " AS " + objectType + " WHERE " + objectType + ".id = @id";
                                       
        IQueryable<Object> query = entitiesContext.CreateQuery<Object>(queryString, new ObjectParameter("id", objectId));
                                        
        foreach (Object result in query)
        {
            return result;
        }
    }
    catch (EntitySqlException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    }
    return null;
