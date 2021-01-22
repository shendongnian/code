    AutoResetEvent processing = new AutoResetEvent(false);
    private void HideWait()
    {
        processing.Set();
    }
    private void ShowWait(object sender, EventArgs e)
    {           
        ThreadPool.QueueUserWorkItem((x) =>
        {
            using (frmWait espera = new frmWait())
            {
                espera.ShowInTaskbar = false;
                espera.Show();
                processing.WaitOne();
                espera.Close();
            }
        });
    }
