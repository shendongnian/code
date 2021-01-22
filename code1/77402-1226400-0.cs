        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = treeView1.HitTest(e.X, e.Y).Node;
                treeView1.SelectedNode = node;
            }
        }
