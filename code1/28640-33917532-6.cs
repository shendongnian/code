        private void Form1_Load(object sender, EventArgs e)
        {
            // Load configuration
            oConfigMng.LoadConfig();
            if (oConfigMng.Config.StartPos.X != 0 || oConfigMng.Config.StartPos.Y != 0)
            {
                Location = oConfigMng.Config.StartPos;
                Size = oConfigMng.Config.StartSize;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save configuration
            oConfigMng.Config.StartPos = Location;
            oConfigMng.Config.StartSize = Size;
            oConfigMng.SaveConfig();
        }
