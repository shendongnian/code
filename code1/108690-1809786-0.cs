    bool m_NeedClose = false;
    
    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        m_NeedClose = true;
        Close();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(m_NeedClose ||
          (e.CloseReason != CloseReason.UserClosing))
        {
            return;
        }
        
        e.Cancel = true;
        this.WindowState = FormWindowState.Minimized;
    }
