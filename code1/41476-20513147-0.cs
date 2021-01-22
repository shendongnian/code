    // in form's constructor
    Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
	private void OnApplicationExit(object sender, EventArgs e)
	{
		try
		{
			if (notifyIcon1!= null)
			{
				notifyIcon1.Visible = false;
				notifyIcon1.Icon = null;
				notifyIcon1.Dispose();
				notifyIcon1= null;
			}
		}
		catch { }
	}
