	protected override void WndProc(ref Message m)
	{
		if (m.Msg == paint)
		{
			if (!highlighting)
			{
				base.WndProc(ref m); // if we decided to paint this control, just call the RichTextBox WndProc
			}
			else
			{
				m.Result = IntPtr.Zero; // not painting, must set this to IntPtr.Zero if not painting otherwise serious problems.
			}
		}
		else
		{
			base.WndProc(ref m); // message other than paint, just do what you normally do.
		}
	}
