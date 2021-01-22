                private void tabControl1_MouseDown(object sender, MouseEventArgs e)
                {
                    if (e.Button != System.Windows.Forms.MouseButtons.Middle)
                        return;
        
                    for (int i = 0; i < MainTabControl.TabPages.Count; i++)
                    {
                        if (this.MainTabControl.GetTabRect(i).Contains(e.Location))
                        {
                            this.MainTabControl.TabPages.RemoveAt(i);
                            return;
                        }
                    }
                }
