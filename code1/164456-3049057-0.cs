    public class YourForm : Form
    {    
        private bool _reallyClose;
    
        private void ContextMenuClick(object sender, EventArgs e)
        {
            _reallyClose = true;
            this.Close();
        }
        
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_reallyClose)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }
    
    }
