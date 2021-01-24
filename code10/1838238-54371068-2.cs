            protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);            //comment this out to prevent default painting 
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(45, 45, 48))) //any color you like  }
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }
