      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         SolidBrush sb = new SolidBrush(Color.Pink);
         g.FillRectangle(sb, e.ClipRectangle);
         sb.Dispose();
         sb = new SolidBrush(Color.Orange);
         g.FillEllipse(sb, 20, 20, 20, 20);
         sb.Dispose();
      }
