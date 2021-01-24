    void LoadFromDatabase(int itemId)
    {
        var sqlcmd = new SqlCommand("SELECT ID FROM X WHERE ID=" +
                            itemId.ToString(), sqlcon);
        var sqldr = sqlcmd.ExecuteReader();
        if (sqldr.Read())
        {
            InvoiceForm.CodeTextBox = sqldr[codecolumn].Tostring();
            InvoiceForm.NameTextBox = sqldr[Namecolumn].Tostring();
            InvoiceForm.BlahTextBox = sqldr[Blahcolumn].Tostring();                               
        }
    }
