    if ( Request.IsAuthenticated )
    {
        // Display
        pnlAuthenticated.Visible = true;
        pnlGuest.Visible = false;
    } 
    else 
    {
        // Display
        pnlAuthenticated.Visible = false;
        pnlGuest.Visible = true;
    }
