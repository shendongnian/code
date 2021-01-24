	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
		if (!Visible)
		{
			_lastState = WindowState;
		}
		else
		{
			if (_lastState == FormWindowState.Maximized)
				WindowState = FormWindowState.Maximized;
		}
	}
	FormWindowState _lastState = FormWindowState.Normal;
