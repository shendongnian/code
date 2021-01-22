    var count = "SELECT COUNT(*) as rowcount FROM table_mysql GROUP BY id";
    
    var countReader = Retrieve(count);
    var countRows = 0;
    try
    {
        while (countReader.Read())
        {
            countRows += int.Parse(countReader.GetValue(0).ToString());
        }
    }
    catch (Exception ex)
    {
        Log.LogMessageToFile("Import.cs -> table_mssql: " + ex.StackTrace + " /n" + ex.Message);
    }
    finally
    {
        if (countReader != null) { countReader.Close(); _crud.close_conn(); }
    }
    
    for (var a = 0; a < countRows; )
    {
        var sql = "SELECT id, traffic_id, dow, uu, imps, impsuu, otsw, otsm FROM table_mysql LIMIT " + a + ", " + (a + 500) + "";
    
        var reader = Retrieve(sql);
        try
        {
            var builder = new StringBuilder();
            builder.Append(
                "SET IDENTITY_INSERT table_mssql ON;INSERT INTO table_mssql(id, traffic_id, dow, uu, imps, impsuu, otsw, otsm) VALUES ");
            while (reader.Read())
            {
                Application.DoEvents();
                try
                {
                    builder.Append("(" + reader.GetValue(0) + ", " + reader.GetValue(1) + ", " +
                                   reader.GetValue(2) +
                                   ", " + reader.GetValue(3) + ", " + reader.GetValue(4) +
                                   ", " + reader.GetValue(5) + ", " + reader.GetValue(6) + ", " +
                                   reader.GetValue(7) +
                                   "), ");
    
                }
                catch (Exception ex)
                {
                    Log.LogMessageToFile("Import.cs -> table_mssql: " + ex.StackTrace + " /n" + ex.Message);
                }
            }
    
            var sqlDB = builder.ToString(0, builder.Length - 2);
    
            sqlDB += ";SET IDENTITY_INSERT table_mssql OFF;";
            if (!InsertDB(sqlDB))
            {
                Log.LogMessageToFile("Import.cs -> table_mssql: No insert happend!");
            }
        }
        catch (Exception ex)
        {
            Log.LogMessageToFile("Import.cs -> table_mssql: " + ex.StackTrace + " /n" + ex.Message);
            return false;
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                _crud.close_conn();
            }
        }
        a = a + 500;
    }
