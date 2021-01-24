    protected void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (e.Item.Selected)
        {
            Color backColor = Color.FromName(e.Item.Text.Substring(e.Item.Text.LastIndexOf(" ") + 1));
            using (SolidBrush bkgrBrush = new SolidBrush(backColor))
            using (SolidBrush foreBrush = new SolidBrush(e.Item.BackColor)) {
                e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                e.Graphics.DrawString(e.Item.Text, e.Item.Font, foreBrush, e.Bounds, StringFormat.GenericTypographic);
            }
        }
        else
        {
            e.DrawBackground();
            Color forecolor = Color.FromName(e.Item.Text.Substring(e.Item.Text.LastIndexOf(" ") + 1));
            using (SolidBrush foreBrush = new SolidBrush(forecolor)) {
                e.Graphics.DrawString(e.Item.Text, e.Item.Font, foreBrush, e.Bounds, StringFormat.GenericTypographic);
            }
        }
    }
    protected void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawBackground();
        string Extra = (e.ColumnIndex == 1) ? (char)32 + "\u2660" + (char)32 : (char)32 + "\u2663" + (char)32;
        e.Graphics.DrawString(Extra + e.Header.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericTypographic);
    }
