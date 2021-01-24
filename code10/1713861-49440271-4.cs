    protected void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.Item.UseItemStyleForSubItems = true;
        int imageOffset = 0;
        Rectangle rect = e.Item.Bounds;
        bool drawImage = !(e.Item.ImageList is null);
        Color itemColor = Color.FromName(e.Item.Text.Substring(e.Item.Text.LastIndexOf(" ") + 1));
        using (StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox)) {
            format.LineAlignment = StringAlignment.Center;
            if (drawImage) {
                imageOffset = e.Item.ImageList.ImageSize.Width + 1;
                rect.Location = new Point(e.Bounds.X + imageOffset, e.Item.Bounds.Y);
                e.Graphics.DrawImage(e.Item.ImageList.Images[e.Item.ImageIndex], e.Bounds.Location);
            }
            if (e.Item.Selected) {
                using (SolidBrush bkgrBrush = new SolidBrush(itemColor))
                using (SolidBrush foreBrush = new SolidBrush(e.Item.BackColor)) {
                    e.Graphics.FillRectangle(bkgrBrush, rect);
                    e.Graphics.DrawString(e.Item.Text, e.Item.Font, foreBrush, rect, format);
                }
            }
            else {
                using (SolidBrush foreBrush = new SolidBrush(itemColor)) {
                    e.Graphics.DrawString(e.Item.Text, e.Item.Font, foreBrush, rect, format);
                }
            }
        }
        e.DrawFocusRectangle();
    }
    protected void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawBackground();
        string Extra = (e.ColumnIndex == 1) ? (char)32 + "\u2660" + (char)32 : (char)32 + "\u2663" + (char)32;
        e.Graphics.DrawString(Extra + e.Header.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericTypographic);
    }
