    private static void DrawCenter(string text, Label label, Point location, Color fontColor, Graphics graphics) {
      Rectangle rect = new Rectangle(location, label.Size);
      SizeF lSize = graphics.MeasureString(text, label.Font, rect.Width);
      PointF lPoint = new PointF((rect.Width - lSize.Width) / 2, (rect.Height - lSize.Height) / 2);
      graphics.DrawString(text, label.Font, new SolidBrush(fontColor), lPoint);
      if (label.BorderStyle != BorderStyle.None) {
        using (Pen p = new Pen(Color.Black)) {
          graphics.DrawRectangle(p, rect);
        }
      }
    }
