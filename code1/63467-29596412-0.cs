    public bool IsOnScreen(Form form)
    {
	    Screen[] screens = Screen.AllScreens;
	    foreach (Screen scrn in screens) {
		    Drawing.Rectangle formRectangle = new Drawing.Rectangle(form.Left, form.Top, form.Width, form.Height);
		    formRectangle.Intersect(scrn.WorkingArea);
		    if (!formRectangle.IsEmpty) {
			    return true;
		    }
	    }
	    return false;
    }
