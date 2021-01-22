    Size size;
    int x;
    int y;
    if (WindowState.Equals(FormWindowState.Normal))
    {
        size = Size;
        if (Location.X + size.Width > Screen.PrimaryScreen.Bounds.Width)
            x = Screen.PrimaryScreen.Bounds.Width - size.Width;
        else
            x = Location.X;
        if (Location.Y + Size.Height > Screen.PrimaryScreen.Bounds.Height)
            y = Screen.PrimaryScreen.Bounds.Height - size.Height;
        else
            y = Location.Y;
    }
    else
    {
	size = RestoreBounds.Size;
	x = (Screen.PrimaryScreen.Bounds.Width - size.Width)/2;
	y = (Screen.PrimaryScreen.Bounds.Height - size.Height)/2;
    }
    Properties.Settings.Position.AsPoint = new Point(x, y); // Property setting is type of Point
    Properties.Settings.Size.AsSize = size;                 // Property setting is type of Size
    Properties.Settings.SplitterDistance.Value = splitContainer1.SplitterDistance; // Property setting is type of int
    Properties.Settings.IsMaximized = WindowState == FormWindowState.Maximized;    // Property setting is type of bool
    Properties.Settings.DropDownSelection = DropDown1.SelectedValue;
    Properties.Settings.Save();
