    private void myTrackBar1_ValueChanged(object sender, EventArgs e) {
      this.Invalidate();
    }
    protected override void  OnPaint(PaintEventArgs e) {
      var chan = this.RectangleToClient(myTrackBar1.RectangleToScreen(myTrackBar1.Channel));
      var slider = this.RectangleToClient(myTrackBar1.RectangleToScreen(myTrackBar1.Slider));
      e.Graphics.DrawLine(Pens.Black, chan.Left + slider.Width / 2, myTrackBar1.Bottom + 5,
        slider.Left + slider.Width / 2, myTrackBar1.Bottom + 5);
    }
