    private void txtWO_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            AcceptInput();
        }
    }
    
    private void btnFill_Click(object sender, EventArgs e)
    {
        AcceptInput();
    }
    
    private void AcceptInput()
    {
        // Do clever stuff here when the user presses enter 
        // in the field, or clicks the button.
    }
