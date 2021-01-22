    //If you can change the event handler for the control 
    //that you are looking at catching the keys.  
    //In the example below textBox1 is using 
    //setting the KeyEventHandler to be KeyDownEvents Method...  
    //this has the KeyCode properties...
    this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvents);
    //This is the code in the event...
     private void KeyDownEvents(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.BrowserBack)
                {
                    MessageBox.Show(e.KeyCode.ToString());
                }
            }
