    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (e.Item.Selected)
        {
            if (e.Item.Index == 0)
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }                       
        }
        else
        {
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
        }
        e.DrawText(TextFormatFlags.TextBoxControl);
    }     
