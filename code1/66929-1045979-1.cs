        private string folder;
        private void Form1_Load(object sender, EventArgs e)
        {
          this.folder = Properties.Settings.Default.MySavedDirectory;
        }
    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          Properties.Settings.Default.MySavedDirectory = this.folder;
          Properties.Settings.Default.Save();
        }
