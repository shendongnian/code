    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    static readonly int SW_SHOWNOACTIVATE = 4;
    AutoResetEvent processing = new AutoResetEvent(false);
    private void HideWait()
    {
        processing.Set();
    }
    private void ShowWait()
    {
        ThreadPool.QueueUserWorkItem(c =>
        {
            using (frmWait espera = new frmWait())
            {
                espera.ShowInTaskbar = false;
                ShowWindow(espera.Handle, SW_SHOWNOACTIVATE);
                processing.WaitOne();
                }
            });
        }
    }
