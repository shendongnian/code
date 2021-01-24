    public void MainForm_Load(object sender, EventArgs e)
    {
        this.Hide(); // Hide the mainform
        using (SplashScreen splash = new SplashScreen())
        {
            if (splash.ShowDialog() == DialogResult.OK)
            {
                // Retrieve any properties from the splash screen here.
                this.Show();
            }
            else
            {
                // user doesn't have permission to use the application so close.
                this.Close();
            }
        }
    }
