    // Determine correct user control to load
    string pathToUserControl = DetermineTopMenu();
    // Load the user control - calling LoadControl forces the correct lifcycle events
    // to fire, and ensures the control is created properly.
    var topMenu = LoadControl(pathToUserControl);
    // Add the control to the menuRow panels control collection.
    menuRow.Controls.Add(topMenu);
