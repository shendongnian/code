    private ReportsBrushes reportsBrushes = new ReportsBrushes();
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        ListBox ctl = sender as ListBox;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        e.DrawFocusRectangle();
        var itemColors = reportsBrushes.GetItemBrushes(ctl.Items[e.Index].ToString(), e.State.HasFlag(DrawItemState.Selected));
        using (StringFormat format = new StringFormat())
        {
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(ctl.Items[e.Index].ToString(), ctl.Font, itemColors.ForeColor, e.Bounds, format);
        }
    }
    private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = listBox1.Font.Height + 4;
    }
