        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds,  Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            Rectangle rectGrid = new Rectangle(this.Location.X, this.Location.Y, this.Width + this.RowHeadersWidth, this.Height + this.ColumnHeadersHeight);
            Bitmap b = new Bitmap(Parent.Width, Parent.Height);
            Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, new Rectangle(0, 0, Parent.Width, Parent.Height));
       
            graphics.DrawImage(b.Clone(rectGrid, System.Drawing.Imaging.PixelFormat.Format32bppRgb), gridBounds);
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
