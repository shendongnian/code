      protected override void PaintBackground(Graphics graphics, Rectangle clipBounds,  Rectangle gridBounds)
      {
        base.PaintBackground(graphics, clipBounds, gridBounds);
        Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
        Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);
        Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
        Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);
        graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
        SetCellsTransparent();
      }
    public void SetCellsTransparent()
    {
        this.EnableHeadersVisualStyles = false;
        this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
        this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;
        foreach (DataGridViewColumn col in this.Columns)
        {
            col.DefaultCellStyle.BackColor = Color.Transparent;
            col.DefaultCellStyle.SelectionBackColor = Color.Transparent;
        }
    }
