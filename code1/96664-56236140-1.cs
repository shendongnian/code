    private void UiControl_Click(object sender, EventArgs e)
    {
    	using (new AppWaitCursor(sender))
    	{
    		LongRunningCall();
    	}
    }
