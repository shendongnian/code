        //Create tabcontrol1
        //asociate with MouseClick event bellow
        //create contextMenuTabs  ContextMenuStrip
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ee = new Point(e.Location.X - panel1.Left, e.Location.Y - panel1.Top);
                for (int i = 0; i < this.tabControl1.TabCount; i++)
                {
                    Rectangle r = this.tabControl1GetTabRect(i);
                    if (r.Contains(ee))
                    {
                        if (this.tabControl1.SelectedIndex == i)
                            this.contextMenuTabs.Show(this.tabControl1, e.Location);
                        else 
                            {
                              //if a non seelcted page was clicked we detected it here!!
                            }
                        break;
                    }
                }
            }
        }
