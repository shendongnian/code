        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            if (DesignMode) return;
            Control tmpParent = Parent;
            int locationX = this.Location.X;
            int locationY = this.Location.Y;
            while (tmpParent.BackgroundImage == null)
            {
                locationX += tmpParent.Location.X;
                locationY += tmpParent.Location.Y;
                tmpParent = tmpParent.Parent;
            }
           
            Rectangle rectSource = new Rectangle(locationX, locationY, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);
            Bitmap b = new Bitmap(tmpParent.ClientRectangle.Width, tmpParent.ClientRectangle.Height);
            Graphics.FromImage(b).DrawImage(tmpParent.BackgroundImage, tmpParent.ClientRectangle);
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
