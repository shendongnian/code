    private void txt_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
        {
            // Allow Digits and BackSpace char
        }        
        else
        {
            e.Handled = true;
        }
    }
