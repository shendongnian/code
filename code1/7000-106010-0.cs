        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.CustomWindowSettings == null)
            {
                Settings.Default.CustomWindowSettings = new WindowSettings();
            }
            Settings.Default.CustomWindowSettings.Record(this, splitContainer1);
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.CustomWindowSettings != null)
            {
                Settings.Default.CustomWindowSettings.Restore(this, splitContainer1);
            }
        }
