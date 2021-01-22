      protected override void OnPaintBackground(PaintEventArgs e) {
        e.Graphics.FillRectangle(Brushes.Black, this.ClientRectangle);
        e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
        for (int x = 0; x < this.AutoScrollMinSize.Width; x += GridSize) 
          e.Graphics.DrawLine(Pens.White, x, 0, x, this.AutoScrollMinSize.Height);
        for (int y = 0; y < this.AutoScrollMinSize.Height; y += GridSize)
          e.Graphics.DrawLine(Pens.White, 0, y, this.AutoScrollMinSize.Width, y);
      }
