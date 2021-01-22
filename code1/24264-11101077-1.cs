    using System.Windows.Forms;
    
    ContextMenuStrip menu;
    
    this.menu.Items.AddRange(new ToolStripItem[] { this.menuItem });
    this.listBox.MouseUp += new MouseEventHandler(this.mouse_RightClick);
    
    private void mouse_RightClick(object sender, MouseEventArgs e)
    {
        int index = this.listBox.IndexFromPoint(e.Location);
        if (index != ListBox.NoMatches)
        {
            menu.Visible = true;
        }
        else
        {
            menu.Visible = false;
        }
    }
