    while (sqldr.Read())
    {
        // Note the ´Text´ property.
        InvoiceForm.CodeTextBox.Text = sqldr[codecolumn].Tostring();
        InvoiceForm.NameTextBox.Text = sqldr[Namecolumn].Tostring();
        InvoiceForm.BlahTextBox.Text = sqldr[Blahcolumn].Tostring();
    }
