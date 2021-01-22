    //this.images is an ImageList with your bitmaps
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 1 && e.RowIndex == -1)
        {
            e.PaintBackground(e.ClipBounds, false);
            Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell
    
            int offset = (e.CellBounds.Width - this.images.ImageSize.Width) / 2;
            pt.X += offset;
            pt.Y += 1;
            this.images.Draw(e.Graphics, pt, 0);
            e.Handled = true;
        }
    }
