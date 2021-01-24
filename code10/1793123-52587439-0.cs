    protected void ASPxGridView1_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        // check column name first
        if (e.Column.FieldName != "BankAccountNumber")
            return;
    
        // get column values for BankAccountNumber
        string value = e.Value.ToString();
    
        // set asterisk to hide first n - 4 digits
        string asterisks = new string('*', value.Length - 4);
    
        // pick last 4 digits for showing
        string last = value.Substring(value.Length - 4, 4);
    
        // combine both asterisk mask and last digits
        string result = asterisks + last;
    
        // display as column text
        e.DisplayText = result;
    }
