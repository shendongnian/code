    public class AutoExpandTreeView : TreeView
    {
        private bool _dragging;
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            _dragging = true;
            base.OnDragEnter(drgevent);
        }
        protected override void OnDragLeave(EventArgs e)
        {
            _dragging = false;
            base.OnDragLeave(e);
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            _dragging = false;
            base.OnDragDrop(drgevent);
        }
        protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        {
            if (_dragging)
                e.Node.Expand();
            base.OnNodeMouseHover(e);
        }
    }
