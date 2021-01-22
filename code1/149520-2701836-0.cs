        bool mDragging;
        private bool onTreeEdge(Point pos) {
            return pos.X >= treeView1.DisplayRectangle.Right - 3;
        }
        private void treeView1_MouseMove(object sender, MouseEventArgs e) {
            treeView1.Cursor = mDragging || onTreeEdge(e.Location) ? Cursors.VSplit : Cursors.Default;
            if (mDragging) treeView1.Width = e.X;
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e) {
            mDragging = onTreeEdge(e.Location);
            if (mDragging) treeView1.Capture = true;
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e) {
            mDragging = false;
        }
