        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.Contains(e.Location) && e.Button == MouseButtons.Right)
            {
                MessageBox.Show("This only displays when the text is right clicked and released. You can show a context menu here instead.");
            }
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Rigth)
            {
                TreeViewHitTestInfo hti =treeView1.HitTest(e.Location);
                if (hti.Location == TreeViewHitTestLocations.Label)
                {
                    MessageBox.Show("This only displays when the text is the target of the right mouse down. You can show a context menu here instead.");
                }
            }
        }
