    using (var conn = _db.OpenConnection())
    {
        var sqlQuery = "SELECT * FROM RotationItem WHERE [RotationItemId] = SCOPE_IDENTITY()";
        // Create a dummy adapter, so we can generate an appropriate INSERT statement
        var dummy = new SqlDataAdapter(sqlQuery, conn);
        var insert = new SqlCommandBuilder(dummy).GetInsertCommand();
        // Append the SELECT to the end of the INSERT command, 
        // and set a flag to copy the result back into the dataSet table row
        insert.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
        insert.CommandText += ";" + sqlQuery;
        // Now proceed as usual...
        var adapter = new SqlDataAdapter(sqlQuery, conn);
        adapter.InsertCommand = insert;
        var dataSet = new DataSet();
        adapter.Fill(dataSet);
        Debug.WriteLine("First fill, rows " + dataSet.Tables[0].Rows.Count);
        var table = dataSet.Tables[0];
        table.Rows.InsertAt(table.NewRow(), 0);
        CopyJsonToRow(table, 0, item);
        if (adapter.Update(dataSet) != 1)
        {
            throw new InvalidOperationException("Insert failed");
        }
        // After insert, the table AUTOMATICALLY has the new row ID (and any other computed columns)
        Debug.WriteLine("The new id is " + table.Rows[0].ItemArray[0]);
    }
