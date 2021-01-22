    private void SetNodeBoldWhenSelected(object sender, DrawTreeNodeEventArgs e)
    {
        if (e.Node == null) return;
        var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
        if (e.Node.IsSelected)
        {
            font = new Font(font, FontStyle.Bold);                
        }
    
        var bounds = new Rectangle( e.Bounds.X,e.Bounds.Y,e.Bounds.Width+20,e.Bounds.Height);
    
        e.Graphics.FillRectangle(SystemBrushes.ControlDarkDark, bounds);
        TextRenderer.DrawText(e.Graphics, e.Node.Text, font, bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
    }
