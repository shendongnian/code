    this.ListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_LeftClick);
    
    private void List_LeftClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int index = this.listBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                // Do something
            }
        }
    }
