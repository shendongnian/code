    var dr = command.ExecuteQuery();
    if (dr.HasRows)
    {
        //Get your ordinals here, before you run through the reader
        int ordinalColumn1 = dr.GetOrdinal("Column1");
        int ordinalColumn2 = dr.GetOrdinal("Column2");
        int ordinalColumn3 = dr.GetOrdinal("Column3");
        while(dr.Read())
        {
            // now access your columns by ordinal inside the Read loop. 
            //This is faster than doing a string column name lookup every time.
            Console.WriteLine("Column1 = " + dr.GetString(ordinalColumn1);
            Console.WriteLine("Column2 = " + dr.GetString(ordinalColumn2);
            Console.WriteLine("Column3 = " + dr.GetString(ordinalColumn3);
        }
    }
