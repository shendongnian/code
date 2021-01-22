	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
		if (m.Msg == Program.WM_ACTIVATEAPP)
			this.Show();
	}
