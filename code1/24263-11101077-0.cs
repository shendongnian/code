    System.Windows.Forms.ContextMenuStrip menu;
    
    this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem});
    this.listBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouse_RightClick);
    
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
