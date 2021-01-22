	//1.  Use the custom control defined in the SplitContainerNoFocus sample
	//2. Insert the following code in your project, and attach these events to all of the SplitContainers that you don't want stealing focus.
	// Temp variable to store a previously focused control
	private Control focused = null; 
	private void splitContainer_MouseDown(object sender, MouseEventArgs e)
	{
	   // Get the focused control before the splitter is focused
	   focused = getFocused(this.Controls);
	}
	private Control getFocused(Control.ControlCollection controls)
	{
	   foreach (Control c in controls)
	   {
		  if (c.Focused)
		  {
			 // Return the focused control
			 return c;
		  }
		  else if (c.ContainsFocus)
		  {
			 // If the focus is contained inside a control's children
			 // return the child
			 return getFocused(c.Controls);
		  }
	   }
	   // No control on the form has focus
	   return null;
	}
	private void splitContainer_MouseUp(object sender, MouseEventArgs e)
	{
	   // If a previous control had focus
	   if (focused != null)
	   {
		  // Return focus and clear the temp variable for 
		  // garbage collection
		  focused.Focus();
		  focused = null;
	   }
	}
