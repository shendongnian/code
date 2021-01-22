    private void button1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) 
    {
       if ((Control.ModifierKeys & Keys.Control) == Keys.Control) 
       {
         MessageBox.Show("Pressed " + Keys.Control);
       }
    }
