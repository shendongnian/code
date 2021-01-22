    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        // Only interested in 2nd column.
        if (e.Header != this.columnHeader2)
        {
            e.DrawDefault = true;
            return;
        }
        e.DrawBackground();
        var imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
        e.Graphics.DrawImage(SystemIcons.Information.ToBitmap(), imageRect);
    }
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
