    // e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | 
    //            TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.WordEllipsis);
    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds,
                          SystemColors.WindowText, SystemColors.Window,
                          TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
