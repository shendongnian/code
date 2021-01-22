    private void myKeyPress(object sender, 
                            System.Windows.Forms.KeyPressEventArgs e) 
    {
       if (((Control.ModifierKeys & Keys.Control) == Keys.Control) 
            && e.KeyChar == 'A')
       {
         SelectAll();
       }
    }
