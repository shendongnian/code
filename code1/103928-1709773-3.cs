    public class AutoExpandTreeView : TreeView
    {
        DelayedAction<TreeNode> _expandNode;
        public AutoExpandTreeView()
        {
            _expandNode = new DelayedAction<TreeNode>((node) => node.Expand(), 500);
        }
        private TreeNode _prevNode;
        protected override void OnDragOver(DragEventArgs e)
        {
            Point clientPos = PointToClient(new Point(e.X, e.Y)); 
            TreeViewHitTestInfo hti = HitTest(clientPos);
            if (hti.Node != null && hti.Node != _prevNode)
            {
                _prevNode = hti.Node;
                _expandNode.RunAfterDelay(hti.Node);
            }
            base.OnDragOver(e);
        }
    }
