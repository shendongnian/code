        bool isRBut = false;
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            isRBut = e.Button == MouseButtons.Right;
            if (isRBut)
            {
                TreeViewHitTestInfo hti =treeView1.HitTest(e.Location);
                if (hti.Location == TreeViewHitTestLocations.Label)                
                    contextMenuStrip1.Show(treeView1, new Point(hti.Node.Bounds.Left, hti.Node.Bounds.Bottom));                
            }
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            isRBut = e.Button == MouseButtons.Right;
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = isRBut;
        }
