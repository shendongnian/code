    private void MyTreeGridview_DrawNode(object sender, DrawTreeNodeEventArgs e) 
    {
        if ((e.State == TreeNodeStates.Selected) && (!MyTreeGridview.Focused))
        {
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            if (fore == Color.Empty)fore = e.Node.TreeView.ForeColor;      
            fore = SystemColors.HighlightText;
            Color highlightColor = SystemColors.Highlight;
            e.Graphics.FillRectangle(new SolidBrush(highlightColor), e.Bounds);
            ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, highlightColor);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, highlightColor, TextFormatFlags.GlyphOverhangPadding);
        }
        else
        {
            e.DrawDefault = true;
        }
    }
