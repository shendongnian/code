    EventHandler handler = delegate(System.Object o, System.EventArgs e)
                   { System.Windows.Forms.MessageBox.Show("Click!"); };
    Button.Click += handler;
    // ... program code
    
    Button.Click -= handler;
