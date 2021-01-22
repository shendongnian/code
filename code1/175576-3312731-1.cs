        void treeView1_DragOver(object sender, DragEventArgs e) {
            var pos = treeView1.PointToClient(new Point(e.X, e.Y));
            var hit = treeView1.HitTest(pos);
            if (hit.Node != null) {
                hit.Node.Expand();
                treeView1.SelectedNode = hit.Node;
            }
        }
