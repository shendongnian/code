        protected override void OnPaintBackground (PaintEventArgs e)
        {
          // do nothing! prevents flicker
        }
        protected override void OnPaint (PaintEventArgs e)
        {
          e.Graphics.FillRectangle (new SolidBrush (BackColor), e.ClipRectangle);
          Point
            mouse = PointToClient (MousePosition);
          e.Graphics.DrawEllipse (new Pen (ForeColor), new Rectangle (mouse.X - 20, mouse.Y - 10, 40, 20));
        }
        protected override void OnMouseMove (MouseEventArgs e)
        {
          base.OnMouseMove (e);
          Invalidate ();
        }
