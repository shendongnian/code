    void adapter_RowUpdated(object sender, System.Data.Common.RowUpdatedEventArgs e)
    {
        if (e.StatementType == StatementType.Insert)
        {
            SQLiteCommand cmdNewID = new SQLiteCommand("SELECT last_insert_rowid()", con);
            e.Row["RowID"] = cmdNewID.ExecuteScalar();
        }
    }
