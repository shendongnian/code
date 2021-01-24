    private void splitContainerHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
            {
                SplitContainer spltcnt = new SplitContainer();
                spltcnt.Dock = DockStyle.Left;
                spltcnt.Orientation = Orientation.Horizontal;
                spltcnt.SplitterWidth = 4;
                spltcnt.Visible = true;
                spltcnt.Size = new System.Drawing.Size(731, 615);
                spltcnt.BorderStyle = BorderStyle.Fixed3D;
                spltcnt.SplitterDistance = 351;
    
                //Manually bind the mouse click events.
                spltcnt.Panel1.MouseClick += Panel1OnMouseClick;
                spltcnt.Panel2.MouseClick += Panel2OnMouseClick;
    
                Controls.Add(spltcnt);
            }
            
            private void Panel1OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
            {
                MessageBox.Show("Panel1");
            }
    
            private void Panel2OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
            {
                MessageBox.Show("Panel2");
            }
