    // Getting the command text from the SQLiteCommandBuilder, but at this
    // point you could simply write it as text directly in the constructor
    SQLiteCommandBuilder cmd_bldr = new SQLiteCommandBuilder(data_adapter);
    using (var cmd = new SQLiteCommand(cmd_bldr.GetInsertCommand(), conn))
    {
        conn.Open();
        // Create the parameters collection, setting the type for each 
        // parameter but without setting an explicit value
        cmd.Parameters.Add("@p1", DbType.Int);
        // create other parameters for each field to insert ....
        using (var transaction = conn.BeginTransaction())
        {
            // Inform the command about the open transaction
            cmd.Transaction = transaction;
 
            // Loop over your table rows....
            foreach(DataRow row in data_table.Rows)
            {
                // get the parameters value from the row's field
                cmd.Parameters["@p1"].Value = row[fieldIndex];
                .... repeat for other parameters ...
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
    }
