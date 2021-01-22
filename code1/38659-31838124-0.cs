    void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(Char.IsNumber(e.KeyChar))
            ...
        else if(Char.IsLetter(e.KeyChar))
            ...
    }
