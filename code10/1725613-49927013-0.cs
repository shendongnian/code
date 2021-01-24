    if(string.IsNullOrEmpty(txteventdate.Text))
    { 
        MessageBox.Show("Date is necessary!");
        return;
    }
    
    if(!DateTime.TryParse(txteventdate.Text, out DateTime parsedDateTime))
    { 
        MessageBox.Show($"Invalid {txteventdate.Text}!");
        return;
    }
