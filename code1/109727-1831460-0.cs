    private void changeFont()
    {
    	Control.ControlCollection controls = tabControl1.Controls;
    	foreach (Control control in controls)
    	{
    		TabPage t = (TabPage)control;
    		Control c = t.GetChildAtPoint(new Point(250, 250));
    		if (c is <your class>)
    		{
    			(<yourclass>)c.changeFont(fontModifier);
    		}
    	}
    }
