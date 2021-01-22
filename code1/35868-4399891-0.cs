		private const int WM_NCHITTEST = 0x0084;
		// Let Windows drag this form for us
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCHITTEST:
					m.Result = (IntPtr)2;	// HTCLIENT
					return;
			}
			base.WndProc(ref m);
		}
