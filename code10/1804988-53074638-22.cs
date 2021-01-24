    private void cboFontFamily_DrawItem(object sender, DrawItemEventArgs e)
    {
        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
        using (FontFamily family = new FontFamily(cboFontFamily.GetItemText(cboFontFamily.Items[e.Index])))
        using (Font font = new Font(family, 10F, FontStyle.Regular, GraphicsUnit.Point)) {
            TextRenderer.DrawText(e.Graphics, family.Name, font, e.Bounds, cboFontFamily.ForeColor, flags);
        }
        e.DrawFocusRectangle();
    }
    private void cboFontFamily_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = (int)this.Font.Height + 4;
    }
    private void cboFontFamily_SelectionChangeCommitted(object sender, EventArgs e)
    {
        fontObject.FontFamily = new FontFamily(cboFontFamily.GetItemText(cboFontFamily.SelectedItem));
        Canvas.Invalidate();
    }
