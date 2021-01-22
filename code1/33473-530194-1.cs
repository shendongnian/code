        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            RectangleF ef;
            base.PaintBackground(graphics, clipBounds, gridBounds);
            if ((this.Enabled && (this.RowCount == 0)) && (this.EmptyText.Length > 0))
            {
                string emptyText = this.EmptyText;
                ef = new RectangleF(4f, (float)(this.ColumnHeadersHeight + 4), (float)(this.Width - 8), (float)((this.Height - this.ColumnHeadersHeight) - 8));
                graphics.DrawString(emptyText, this.Font, Brushes.LightGray, ef);
            }
        }
