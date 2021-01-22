    protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
    {
        base.PaintBackground(graphics, clipBounds, gridBounds);
        if (main.ActiveForm != null && this.Parent.BackgroundImage != null)
        {
            Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(-3, 3, rectSource.Width, rectSource.Height);
            Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
            Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);
            graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
            SetCellsTransparent();
        }
    }
