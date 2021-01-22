		[DllImport("user32.dll")]
		private static extern void EnableWindow(IntPtr handle, bool enable);
		protected override void WndProc(ref System.Windows.Forms.Message msg)
		{
			if (msg.Msg == 0x000a /* WM_ENABLE */ && msg.WParam == IntPtr.Zero)
			{
				EnableWindow(this.Handle, true);
				return;
			}
			base.WndProc(ref msg);
		}
