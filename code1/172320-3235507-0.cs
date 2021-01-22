        static void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Left Button Clicked"); // & do what ever you want
            }
            else
            {
                updateMenuItems(notifyIcon.ContextMenuStrip); 
            }
        }
