    private void MakeControlsInvisible(Control container)
    {
        foreach (Control control in container.Controls)
        {
            control.Visible = false;
    		if(control.Controls.Count > 0)
    		{
    			MakeControlsInvisible(control);
    		}
        }
    }
