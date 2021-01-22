    void KeyPress(object sender, KeyPressEventArgs e)
    {    
        if(Char.IsNumber(e.KeyChar) && Char.IsControl(e.KeyChar))
        {
            //The character is a number or a control key, so handle the event
            e.Handled = true;
        }
    }
