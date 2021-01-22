    // Return True if at least the percent specified of the rectangle is shown on the total screen area of all monitors, otherwise return False.
    public bool IsOnScreen(System.Drawing.Rectangle Rec, double MinPercentOnScreen = 0.2)
    {
        double PixelsVisible = 0;
	    foreach (Screen scrn in Screen.AllScreens) {
		    System.Drawing.Rectangle r = System.Drawing.Rectangle.Intersect(Rec, scrn.WorkingArea);
		    // intersect rectangle with screen
		    if (r.Width != 0 & r.Height != 0) {
			    PixelsVisible += (r.Width * r.Height);
			    // tally visible pixels
		    }
	    }
	    return PixelsVisible >= (Rec.Width * Rec.Height) * MinPercentOnScreen;
    }
