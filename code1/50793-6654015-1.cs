    private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true; //this is to handle the textbox Key press event
        if (int.TryParse(e.KeyChar.ToString(), out _intTemp) == false && e.KeyChar != /* here we should write the key char of Backspace keyword*/))
        {
            if (txtEmpName.TextLength < 15)
            {
                txtEmpName.Text += e.KeyChar;
            }
        }
        else if (e.KeyChar == /* here we should write the key char of Backspace keyword*/)
        {
            e.Handled = false;
        }
        txtEmpName.SelectionStart = txtEmpName.TextLength;
    }
