    private void tabControl1_MouseDown(object sender, MouseEventArgs e)
    {
        Rectangle r = tabControl1.GetTabRect(this.tabControl1.SelectedIndex);
        Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
        if (closeButton.Contains(e.Location))
        {
            this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab); 
        }
    }
