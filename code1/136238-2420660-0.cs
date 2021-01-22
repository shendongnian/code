    public class MyTreeView : TreeView
    {
        bool isLeftMouseDown = false;
        bool isRightMouseDown = false;
        public MyTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TrackMouseButtons(e);
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            TrackMouseButtons(e);
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            TrackMouseButtons(e);
            base.OnMouseMove(e);
        }
        private void TrackMouseButtons(MouseEventArgs e)
        {
            isLeftMouseDown = e.Button == MouseButtons.Left;
            isRightMouseDown = e.Button == MouseButtons.Right;
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // don't call the base or it will goof up your display!
            // capture the selected/focused states
            bool isFocused = (e.State & TreeNodeStates.Focused) != 0;
            bool isSelected = (e.State & TreeNodeStates.Selected) != 0;
            // set up default colors.
            Color color = SystemColors.WindowText;
            Color backColor = BackColor;
            if (isFocused && isRightMouseDown)
            {
                // right clicking on a 
                color = SystemColors.HighlightText;
                backColor = SystemColors.Highlight;
            }
            else if (isSelected && !isRightMouseDown)
            {
                // if the node is selected and we're not right clicking on another node.
                color = SystemColors.HighlightText;
                backColor = SystemColors.Highlight;
            }
            using (Brush sb = new SolidBrush(backColor))
                e.Graphics.FillRectangle(sb,e.Bounds);
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.SingleLine |
               TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Bounds, color, backColor, flags);
        }
    }
