    using(OleDbConnection con = new OleDbConnection(......)
    { 
        con.Open();
        string[] rest = new string[] { null, null, tableName, null };
        var schema = con.GetSchema("COLUMNS", rest);
        foreach (DataRow row in schema.Rows)
            Console.WriteLine($"Column={row["COLUMN_NAME"]}, NULLABLE={row["IS_NULLABLE"]}");
    }
