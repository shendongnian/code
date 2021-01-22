    private void InputsUserControl_Load(object sender, EventArgs e)
    {
        altNameTextBox.GotFocus += new EventHandler(altNameTextBox_GotFocus);
    }
    
    void altNameTextBox_GotFocus(object sender, EventArgs e)
    {
        string s = nameTextBox.Text.Trim();
    
        if (!string.IsNullOrEmpty(s))
        {
            this.Parent.SelectNextControl(this, true, true, true, false);
        }
    
    }
