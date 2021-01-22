    // Return True if any part of the given Rectangle is inside the WorkingArea of any screen, otherwise return False.
    public bool IsOnScreen(Drawing.Rectangle Rec)
    {
	
	    Screen[] screens = Screen.AllScreens;
	    foreach (Screen scrn in screens) {
		    Rec.Intersect(scrn.WorkingArea);
		    if (!Rec.IsEmpty) {
			    return true;
		    }
	    }
	    return false;
    }
