    bool AllowResize;
    bool DoTracking;  
    
    private void MyControl_MouseDown(object sender, MouseEventArgs e)
    {
    	if (AllowResize)
    	{
    		DoTracking = true;
                    ControlPaint.DrawReversibleFrame(new Rectangle(this.PointToScreen(new Point(1,1)),
    		this.Size), Color.DarkGray, FrameStyle.Thick);
    	}
    }
