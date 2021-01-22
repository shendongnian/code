	partial class Form1 : Form
	{
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_SYSCOMMAND)
			{
				int wparam = m.WParam.ToInt32() & 0xfff0;
				if (wparam == SC_MAXIMIZE)
					LastWindowState = FormWindowState.Maximized;
				else if (wparam == SC_RESTORE)
					LastWindowState = FormWindowState.Normal;
			}
			base.WndProc(ref m);
		}
		private const int WM_SYSCOMMAND = 0x0112;
		private const int SC_MAXIMIZE = 0xf030;
		private const int SC_RESTORE = 0xf120;
		private FormWindowState LastWindowState;
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
			{
				Properties.Settings.Default.WindowLocation = Location;
				Properties.Settings.Default.WindowSize = Size;
			}
			else
			{
				Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
				Properties.Settings.Default.WindowSize = RestoreBounds.Size;
			}
			if (WindowState == FormWindowState.Minimized)
			{
				Properties.Settings.Default.WindowState = LastWindowState;
			}
			else
			{
				Properties.Settings.Default.WindowState = WindowState;
			}
			Properties.Settings.Default.Save();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.WindowSize != new Size(0, 0))
			{
				Location = Properties.Settings.Default.WindowLocation;
				Size = Properties.Settings.Default.WindowSize;
				WindowState = Properties.Settings.Default.WindowState;
			}
		}
