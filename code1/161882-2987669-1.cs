    private void parentControl_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.NumPad0)
            this.buttonZero.PerformClick();
        else if (e.KeyCode == Keys.NumPad1)
            this.buttonOne.PerformClick();
        // and so on... 
    }
 
