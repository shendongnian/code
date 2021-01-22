    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		Point pt = TargetControl.PointToClient(Cursor.Position);
    		Rectangle rc = TargetControl.ClientRectangle;
    		if (rc.Contains(pt))
    		{
    			// do what would be done on MouseEnter
    		}
    	}
    }
