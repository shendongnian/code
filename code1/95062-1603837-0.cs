    // Connect an event handler to the KeyPress event
    this.KeyPress += new KeyPressEventHandler(OnKeyPress);
    
    private void OnKeyPress(object sender, KeyPressEventArgs ke)
    {
        // Determine if ESC key value is pressed.
        if (ke.KeyChar == (Char)Keys.Escape)
        {
            // Handle the event to provide functionality.
            ke.Handled = true;
    
            // Add your event handling code here.
            MessageBox.Show("Back key was pressed.");
        }
    }
