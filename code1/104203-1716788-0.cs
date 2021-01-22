    class TrayForm : Form
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                this.Hide();
                this.notifyIcon.Visible = true;
            }
    
            base.OnFormClosing(e);
        }
    
        protected override void OnSizeChanged(EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
    
            base.OnSizeChanged(e);
        }
    }
