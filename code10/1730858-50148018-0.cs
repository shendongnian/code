    private void txtPM_TextChanged(object sender, EventArgs e)
    {
        string fee = lblFee.Text.Trim();
        string pm = txtPM.Text.Trim();
    
        decimal number = 0;
        decimal number2 = 0;
    
        if(!string.IsNullOrWhiteSpace(fee)) number = Convert.ToDecimal(fee);
        if(!string.IsNullOrWhiteSpace(pm)) number2 = Convert.ToDecimal(pm);
    
        decimal minus = number2 - number;
        txtChange.Text = minus.ToString().Trim();
    }
