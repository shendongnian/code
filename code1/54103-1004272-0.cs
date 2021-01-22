        int updated = 0;
        System.Data.DataRow[] updatedRows = dataTable.Select("", "", System.Data.DataViewRowState.Added);
        bool closed = (this.Connection.State == System.Data.ConnectionState.Closed);
        if (closed) 
            this.Connection.Open();
        foreach (System.Data.DataRow row in updatedRows)
        {
            updated+=this.Adapter.Update(new global::System.Data.DataRow[] { row });
            decimal identity = (decimal)this.GetIdentity();
            row[0] = System.Decimal.ToInt64(identity);
            row.AcceptChanges();
        }
        if (closed)
            this.Connection.Close();
        return updated;
    }
