    private void Main_Load(object sender, EventArgs e)
    {
        this.Location = Settings.Default.WindowLocation;
    }
    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        Settings.Default.WindowLocation = this.Location;
        Settings.Default.Save();
    }
