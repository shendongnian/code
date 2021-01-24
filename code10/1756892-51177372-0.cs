    try
    {
        using(var dr = DB.ExecuteReader(storedProcedureName, param1, param2))
        {
            dr.Read(); 
            // It should be probably be while(dr.Read()) { /* do something with the data */ }
        }
    }
    catch(Exception ex)
    {
    // Do something with the exception!
    }
