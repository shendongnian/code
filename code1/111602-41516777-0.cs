        private void Form1_Load(object sender, EventArgs e)
        {
            this.RestoreWindowPosition();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveWindowPosition();
        }
        private void RestoreWindowPosition()
        {
            if (Settings.Default.HasSetDefaults)
            {
                this.WindowState = Settings.Default.WindowState;
                this.Location = Settings.Default.Location;
                this.Size = Settings.Default.Size;
            }
        }
        private void SaveWindowPosition()
        {
            Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.Location = this.Location;
                Settings.Default.Size = this.Size;
            }
            else
            {
                Settings.Default.Location = this.RestoreBounds.Location;
                Settings.Default.Size = this.RestoreBounds.Size;
            }
            Settings.Default.HasSetDefaults = true;
            Settings.Default.Save();
        }
