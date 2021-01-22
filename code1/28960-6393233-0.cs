		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;
		private static void SendLeftMouseClick()
		{
			int x = Cursor.Position.X;
			int y = Cursor.Position.Y;
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
		}
     	public Form1()
		{
			InitializeComponent();
			tabControl1.MouseDown += new MouseEventHandler(tabControl1_MouseDown);
			tabControl1.MouseUp += new MouseEventHandler(tabControl1_MouseUp);
		}
		void tabControl1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				// Send a left mouse click to select the tab that the user clicked on.
				SendLeftMouseClick();
			}
		}
		void tabControl1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				// To show a context menu for only the tab button but not the content of the tab,
				// we must show it in the tab control's mouse up event.
				contextMenuStrip1.Show((Control)sender, e.Location);
			}
		}
