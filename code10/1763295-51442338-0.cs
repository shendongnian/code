    /// <summary>
    /// Sets the location of the form to primary screen.
    /// </summary>
    /// <param name="this">Instance of the form.</param>
    /// <param name="x">The x coordinate of the form's location.</param>
    /// <param name="y">The y coordinate of the form's location.</param>
    public static void SetPrimaryLocation(this Form @this, int x = 0, int y = 0)
    {
        var rect = Screen.PrimaryScreen.WorkingArea;
        @this.Location = new Point(rect.X + x, rect.Y + y);
    }
