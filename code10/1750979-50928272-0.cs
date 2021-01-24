    select count(*) as CountInvoice where invoice1=@invoice1 or invoice2=@invoice2
    
    
    using (SqlCommand command = new SqlCommand("sp_Count", conn))
    {
    
        foreach (TextBox textBox in placehldr1.Controls.OfType<TextBox>())
        {
    
            count1 += 1;
            count2 += 1;
            command.CommandType = CommandType.StoredProcedure;
            string invoice = textBox.Text.TrimEnd();
            string parameter1 = string.Format("@invoice1", count1);
            string parameter2 = string.Format("@invoice2", count2);
            command.Parameters.AddWithValue(parameter, invoice);
            int invoiceCount = (int)command.ExecuteScalar();
    
            if (invoiceCount > 0)
            {
    
                lblError.Text = "Invoice number already exist";
                return;
            }
            command.Parameters.Clear();
        }
