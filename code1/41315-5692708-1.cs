    class MyTransparentTrackBar : TrackBar
    {
    	protected override void OnCreateControl()
    	{
    		SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    		if (Parent != null)
    			BackColor = Parent.BackColor;
    
    		base.OnCreateControl();
    	}
    }
