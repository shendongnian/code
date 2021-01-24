    if (decimal.TryParse(lbl_price.Text.Trim(), out value1))
            {
                Total = Convert.ToDecimal(lbl_price.Text); //Issue is here?      
            }
            if (decimal.TryParse(txt_amount.Text.Trim(), out value2))
            {
    
                Paid = Convert.ToDecimal(txt_amount.Text);          
            }
            if (decimal.TryParse(lbl_totalprice.Text.Trim(), out value3))
            {
                Change = Convert.ToDecimal(lbl_totalprice.Text);
            }
            Change = Paid - Total;
