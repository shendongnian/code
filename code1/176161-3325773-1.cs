    public class AllowCloseEventArgs : EventArgs
    {
        public bool AllowClose = true;
    }
    public void AllowClose(object sender, AllowCloseEventArgs e)
    { e.AllowClose = false; }
