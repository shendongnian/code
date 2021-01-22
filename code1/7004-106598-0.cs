    private void MainForm_Load(object sender, EventArgs e) {
      RestoreState();
    }
    
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      SaveState();
    }
      
    private void SaveState() {
      if (WindowState == FormWindowState.Normal) {
        Properties.Settings.Default.MainFormLocation = Location;
        Properties.Settings.Default.MainFormSize = Size;
      } else {
        Properties.Settings.Default.MainFormLocation = RestoreBounds.Location;
        Properties.Settings.Default.MainFormSize = RestoreBounds.Size;
      }
      Properties.Settings.Default.MainFormState = WindowState;
      Properties.Settings.Default.SplitterDistance = splitContainer1.SplitterDistance;
      Properties.Settings.Default.Save();
    }
    
    private void RestoreState() {
      if (Properties.Settings.Default.MainFormSize == new Size(0, 0)) {
        return; // state has never been saved
      }
      StartPosition = FormStartPosition.Manual;
      Location = Properties.Settings.Default.MainFormLocation;
      Size = Properties.Settings.Default.MainFormSize;
      // I don't like an app to be restored minimized, even if I closed it that way
      WindowState = Properties.Settings.Default.MainFormState == 
        FormWindowState.Minimized ? FormWindowState.Normal : Properties.Settings.Default.MainFormState;
      splitContainer1.SplitterDistance = Properties.Settings.Default.SplitterDistance;
    }
