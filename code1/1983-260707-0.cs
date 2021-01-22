    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Properties.Settings.Default.MyState = this.WindowState;
        if (this.WindowState == FormWindowState.Normal)
        {
           Properties.Settings.Default.MySize = this.Size;
           Properties.Settings.Default.MyLoc = this.Location;
        }
        else
        {
           Properties.Settings.Default.MySize = this.RestoreBounds.Size;
           Properties.Settings.Default.MyLoc = this.RestoreBounds.Location;
        }
        Properties.Settings.Default.Save();
    }
    private void MyForm_Load(object sender, EventArgs e)
    {
        this.Size = Properties.Settings.Default.MySize;
        this.Location = Properties.Settings.Default.MyLoc;
        this.WindowState = Properties.Settings.Default.MyState;
    } 
