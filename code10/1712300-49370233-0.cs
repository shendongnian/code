    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.Clear(Color.White);
      int x = 10;
      int y = 10;
      int width = 148;
      int height = 64;
      int lean = 36;
      Color[] colors = new[] { Color.FromArgb(169, 198, 254),
                               Color.FromArgb(226, 112, 112),
                               Color.FromArgb(255, 226, 112),
                               Color.FromArgb(112, 226, 112),
                               Color.FromArgb(165, 142, 170)};
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      for (int i = 0; i < colors.Length; ++i) {
        using (SolidBrush br = new SolidBrush(colors[i])) {
          e.Graphics.FillPolygon(br, new Point[] { new Point(x, y),
                                                   new Point(x + lean, y + height),
                                                   new Point(x + lean + width, y + height),
                                                   new Point(x + width, y)});
          x += width;
        }
      }
    }
