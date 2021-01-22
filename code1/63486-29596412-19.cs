    // Return True if a certain percent of a rectangle is shown across the total screen area of all monitors, otherwise return False.
    public bool IsOnScreen(System.Drawing.Point RecLocation, System.Drawing.Size RecSize, double MinPercentOnScreen = 0.2)
    {
        double PixelsVisible = 0;
        System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(RecLocation, RecSize);
        foreach (Screen Scrn in Screen.AllScreens)
        {
            System.Drawing.Rectangle r = System.Drawing.Rectangle.Intersect(Rec, Scrn.WorkingArea);
            // intersect rectangle with screen
            if (r.Width != 0 & r.Height != 0)
            {
                PixelsVisible += (r.Width * r.Height);
                // tally visible pixels
            }
        }
        return PixelsVisible >= (Rec.Width * Rec.Height) * MinPercentOnScreen;
    }
