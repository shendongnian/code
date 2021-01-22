    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
      e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image img = Properties.Resources.progress;
      int w = this.ClientSize.Width + this.ClientSize.Width / img.Width;
      int h = this.ClientSize.Height + this.ClientSize.Height / img.Height;
      Rectangle rc = new Rectangle(0, 0, w, h);
      e.Graphics.DrawImage(img, rc);
    }
