    this.Hide();
    hideTimer = new System.Windows.Forms.Timer() { Interval = 1000 };
    hideTimer.Tick += (ts, te) => {
      hideTimer.Stop();
      hideTimer.Dispose();
      Rectangle bounds = Screen.GetBounds(this);
      using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
        using (Graphics g = Graphics.FromImage(bitmap)) {
          g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        }
        bitmap.Save(fileName, ImageFormat.Png);
      }
      this.Show(this.Owner);
    };
    hideTimer.Start();
