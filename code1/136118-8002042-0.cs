    // This getYoungestChildUnderMouse(Control) method will recursively navigate a       
    // control tree and return the deepest non-container control found under the cursor.
    // It will return null if there is no control under the mouse (the mouse is off the
    // form, or in an empty area of the form).
    // For example, this statement would output the name of the control under the mouse
    // pointer (assuming it is in some method of Windows.Form class):
    // 
    // Console.Writeline(ControlNavigatorHelper.getYoungestChildUnderMouseControl(this).Name);
    
        public class ControlNavigationHelper
	    {
		    public static Control getYoungestChildUnderMouse(Control topControl)
		    {
			    return ControlNavigationHelper.getYoungestChildAtDesktopPoint(topControl, System.Windows.Forms.Cursor.Position);
		    }
		    private static Control getYoungestChildAtDesktopPoint(Control topControl, System.Drawing.Point desktopPoint)
		    {
			    Control foundControl = topControl.GetChildAtPoint(topControl.PointToClient(desktopPoint));
			    if ((foundControl != null) && (foundControl.HasChildren))
				    return getYoungestChildAtDesktopPoint(foundControl, desktopPoint);
			    else
				    return foundControl;
		    }
	    }
