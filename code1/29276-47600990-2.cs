    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Text
        string text = ((Control) sender).Text;
    
        // Is Negative Number?
        if (e.KeyChar == '-' && text.Length == 0)
        {
            e.Handled = false;
            return;
        }
    
        // Is Float Number?
        if (e.KeyChar == '.' && text.Length > 0 && !text.Contains("."))
        {
            e.Handled = false;
            return;
        }
    
        // Is Digit?
        e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
    }
