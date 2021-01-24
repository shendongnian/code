    private Color colour = Color.Black;
    private Random rnd = new Random();
    private void timer1_Tick(object sender, EventArgs e) {
      colour = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
      this.Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e) {      
      base.OnPaint(e);
      e.Graphics.Clear(Color.White);
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (SolidBrush br = new SolidBrush(colour)) {
        e.Graphics.FillEllipse(br, new Rectangle(16, 16, 64, 64));
      }
    }
