    // Runs *before* the button event handler
    protected void Page_Load() {
        _myConfirmationMessage.Visible = false;
    }
    // Runs *after* the button event handler
    protected void Page_PreRender() {
        // (...Code to populate page controls with database data goes here...)
    }
    // Event handler for an asp:Button on the page
    protected void myButton_Click(object sender, EventArgs e) {
        // (...Code to update database data goes here...)
        _myConfirmationMessage.Visible = true;
    }
