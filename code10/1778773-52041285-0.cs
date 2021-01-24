    public static class Settings
    { 
        private static bool _checkChanged;
        public static CheckChanged
        {
             get { return _checkChanged; }
             set { _checkChanged = value; }
        }
    }
    public void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
         Settings.CheckChanged = checkBox1.Checked;
    }
