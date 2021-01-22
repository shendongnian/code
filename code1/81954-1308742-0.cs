        protected override void DefWndProc(ref Message m) {
            if (m.Msg == 515) { /* WM_LBUTTONDBLCLK */
                int lparam = m.LParam.ToInt32();
                Point p = new Point(
                  (lparam & 0xffff),
                  ((lparam >> 16) & 0xffff));
                TreeNode n = this.GetNodeAt(p);
                if (n != null && p.X >= n.Bounds.Left) {
                    //Node n was double clicked, and will not be automatically
                    //expanded or collapsed.
                    TreeNodeMouseClickEventArgs e = 
                      new TreeNodeMouseClickEventArgs(
                      n, MouseButtons.Left, 2, p.X, p.Y);
                    this.OnNodeMouseDoubleClick(e);
                }
            }
            else
                base.DefWndProc(ref m);
        }
