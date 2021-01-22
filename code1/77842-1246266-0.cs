    private void Form1_Load( object sender, EventArgs e )
    {
       Properties.Settings.Default.TimesRun = timesrun++;
       Properties.Settings.Default.Save();
    }
