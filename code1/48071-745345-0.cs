    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
         if (e.Button == MouseButtons.Middle)
         {
              // choose tabpage to delete like below
              tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
         }
    }
