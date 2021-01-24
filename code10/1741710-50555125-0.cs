     private void classAinput_KeyPressed(object sender, KeyPressEventArgs e)
     {
        if (!char.IsDigit(e.KeyChar))
            e.Handled = true;
        else
        {
            invalidFormatError();
    
        }
        e.Handled = true;
     }
