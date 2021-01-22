    private void comBox_TextChanged(object sender, EventArgs e)
    {
    	if (comBox.TextLength == 0)
    	{
    		// Set a breakpoint here.
    		Trace.WriteLine("TextBox empty");
    	}
    }
