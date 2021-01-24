    public void txtChanged(object sender, EventArgs e)
    {
        //Get text
        string text = ((TextBox)sender).Text;
        Debug.WriteLines("Current value is: " + text);
    }
