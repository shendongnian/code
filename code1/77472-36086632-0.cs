    protected void Form_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)  // or Key.Enter or Key.Return
        {
            MessageBox.Show("Enter pressed", "KeyPress Event");                
        }
    }
