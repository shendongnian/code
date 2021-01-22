        private void MyForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsMaximized)
                WindowState = FormWindowState.Maximized;
            else if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(Properties.Settings.Default.WindowPosition)))
            {
                StartPosition = FormStartPosition.Manual;
                DesktopBounds = Properties.Settings.Default.WindowPosition;
                WindowState = FormWindowState.Normal;
            }
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IsMaximized = WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.WindowPosition = DesktopBounds;
            Properties.Settings.Default.Save();
        }
