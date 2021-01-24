    try
    {
        using(var dr = DB.ExecuteReader(storedProcedureName, param1, param2))
        {
            dr.Read(); 
        }
    }
    catch(Exception ex)
    {
    }
