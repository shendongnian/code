    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
    }
    
    // set your Form's 'Top here ...
    private void Form1_LocationChanged(object sender, EventArgs e)
    {
        this.Top = 100;
        this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
    }
    
    private void Form1_VisibleChanged(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
    }
    
    private void Form1_Deactivate(object sender, EventArgs e)
    {
        this.Activate();
    }
    
    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("button1 is alive");
    }
