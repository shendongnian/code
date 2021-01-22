    public void AccessBulkCopy(DataTable table)
    {
        foreach (DataRow r in table.Rows)
            r.SetAdded();
        var myAdapter = new OleDbDataAdapter("SELECT * FROM " + table.TableName, _myAccessConn);
        
        var cbr = new OleDbCommandBuilder(myAdapter);
        cbr.QuotePrefix = "[";
        cbr.QuoteSuffix = "]";
        cbr.GetInsertCommand(true);
        
        myAdapter.Update(table);
    }
