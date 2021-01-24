    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    public class ExTreeView : TreeView
    {
        private const int WM_LBUTTONDBLCLK = 0x0203;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK) {
                var info = this.HitTest(PointToClient(Cursor.Position));
                if (info.Location == TreeViewHitTestLocations.StateImage) {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        public IEnumerable<TreeNode> Ancestors(TreeNode node)
        {
            while (node.Parent != null) {
                node = node.Parent;
                yield return node;
            }
        }
        public IEnumerable<TreeNode> Descendants(TreeNode node)
        {
            foreach (TreeNode c1 in node.Nodes) {
                yield return c1;
                foreach (TreeNode c2 in Descendants(c1)) {
                    yield return c2;
                }
            }
        }
    }
