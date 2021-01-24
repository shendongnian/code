    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index> -1)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(),
                                  e.Font, Brushes.Black, e.Bounds.Height + 10, e.Bounds.Y, 
                                  StringFormat.GenericTypographic);
            e.Graphics.DrawImage(this.imageList1.Images[e.Index],
                                 new Rectangle(e.Bounds.Location,
                                 new Size(e.Bounds.Height - 2, e.Bounds.Height - 2)));
        }
    }
