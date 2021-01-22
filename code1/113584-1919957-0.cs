	// Draw Expand (plus/minus) icon if required
	if (ShowPlusMinus && e.Node.Nodes.Count > 0)
	{
		// Use the VisualStyles renderer to use the proper OS-defined glyphs
		Rectangle expandRect = new Rectangle(iconLeft-1, midY - 7, 16, 16);
		VisualStyleElement element = (e.Node.IsExpanded) ? VisualStyleElement.TreeView.Glyph.Opened
														 : VisualStyleElement.TreeView.Glyph.Closed;
		VisualStyleRenderer renderer = new VisualStyleRenderer(element);
				renderer.DrawBackground(e.Graphics, expandRect);
	}
