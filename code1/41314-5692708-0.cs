    class MyTransparentTrackBar : TrackBar
    {
    	protected override void OnCreateControl()
    	{
    		if (Parent != null)
    			BackColor = Parent.BackColor;
    
    		base.OnCreateControl();
    	}
    }
