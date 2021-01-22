    ToolTip tooltip = new ToolTip();
    tooltip.SetToolTip(grid, "your caption here");
    tooltip.Popup += HandleToolTipPopup;
    tooltip.AutoPopDelay = {time to display tooltip};
    private void HandleToolTipPopup(object sender, PopupEventArgs e)
    {
        Point mouseLocation = Control.MousePosition;
        Point relativeLocation = grid.PointToClient(mouseLocation);
        
        // Check to see if it is within the area to popup on.
        // Set e.Cancel to false if not.
    }
