    private void Window_Closed(object sender, EventArgs e)
    {
        Properties.Settings.Default.WinMainLocationX = this.Left; // ok
        Properties.Settings.Default.WinMainLocationY = this.Top; // ok
        Properties.Settings.Default.WinMain_size = new Size(this.Width, this.Height); // crucial setting
        Properties.Settings.Default.WinMain_state = this.WindowState; // ok
    
        Properties.Settings.Default.Save();
        Environment.Exit(0);
    }
