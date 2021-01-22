    private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            this.allowshowdisplay = true;
            this.Visible = !this.Visible;                
        }
    }
