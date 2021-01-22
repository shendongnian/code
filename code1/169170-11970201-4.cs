    void KeyPress(object sender, KeyPressEventArgs e)
    {    
        if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
        {
            //The char is not a number or a control key
            //Handle the event so the key press is ignored
            e.Handled = true;
        }
    }
