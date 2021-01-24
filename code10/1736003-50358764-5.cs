    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.WindowsShutDown) return; // Go ahead and shutdown.
		
		if (!SafeToClose())
		{
			// Optional:
			if (MessageBox.Show("Important process is running. Stay?",...) == DialogResult.Yes)
			{
				e.Cancel = true;
			}
			
			// Or directly:
			//e.Cancel = true;
		}
	}
