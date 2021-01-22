private void timer1_Tick(object sender, EventArgs e)
{
    if ((this.WindowState == FormWindowState.Minimized) && !_isProcessing)
    {
        _isProcessing = true;
        // Do stuff
        _isProcessing = false;
    }
}
