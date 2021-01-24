    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
		// e.Cancel = true;
		
		// Or..
		
        if (e.CloseReason == CloseReason.UserClosing || 
			e.CloseReason == CloseReason.WindowsShutDown)
		{
			e.Cancel = true;
		}
    }
