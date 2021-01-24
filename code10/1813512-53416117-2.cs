    while (sqldr.Read())
    {
        //textbox                  string
        InvoiceForm.CodeTextBox = sqldr[codecolumn].Tostring();
        InvoiceForm.NameTextBox = sqldr[Namecolumn].Tostring();
        InvoiceForm.BlahTextBox = sqldr[Blahcolumn].Tostring();
    }
