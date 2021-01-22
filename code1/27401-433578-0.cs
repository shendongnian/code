    Point mLastPos;
    private void button1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        this.Location = new Point(this.Location.X + e.X - mLastPos.X,
          this.Location.Y + e.Y - mLastPos.Y);
      }
      // NOTE: else is intentional!
      else mLastPos = e.Location;
    }
