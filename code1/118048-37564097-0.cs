    private Form help;
    
    private void heToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (help == null || (help != null && help.IsDisposed))
            {
                help = new Form();
            }
            if (!help.Visible)
            {
                help.Show();
            }
            else
            {
                help.BringToFront();
            }
        }
