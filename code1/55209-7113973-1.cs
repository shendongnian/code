    //  This method is designed to simulate an end-user pressing the ENTER key.
    private void CheckKeys(object sender, KeyPressEventArgs e)
    {
        //  Set the key to be pressed; in this case, the ENTER key.
        if (e.KeyChar == (char)13)
        {
            //  ENTER key pressed.
            e.Handled = true;
        }
    }
