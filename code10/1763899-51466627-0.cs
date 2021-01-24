    Timer timer;
    private bool TimerStarted = false;
    private float ProgressMaxValue = 100;
    private float Progress = 0;
    private int seconds = 0;
    private int cents = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        if (TimerStarted) { TimerStop(); return; }
        timer = new Timer();
        timer.Enabled = true;
        timer.Interval = 20;
        Progress = 0;
        seconds = 0;
        cents = 0;
        timer.Tick += (s, ev) => {
            ++Progress;
            if (Progress > ProgressMaxValue) { TimerStop(); return; }
            cents += (timer.Interval / 5);
            if (cents > 99) { cents = 0; ++seconds; }
            this.label1.Invalidate();
        };
        TimerStarted = true;
        timer.Start();
    }
    private void TimerStop()
    {
        timer.Stop();
        timer.Dispose();
        TimerStarted = false;
    }
    private void label1_Paint(object sender, PaintEventArgs e)
    {
        StringFormat format = new StringFormat() {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        e.Graphics.Clear(this.label1.BackColor);
        Rectangle rect = label1.ClientRectangle;
        rect.Inflate(-1, -1);
        e.Graphics.DrawRectangle(Pens.LimeGreen, rect);
        RectangleF ProgressBar = new RectangleF(
                    new PointF(3, 3),
                    new SizeF((((float)rect.Width - 3) / ProgressMaxValue) * Progress, rect.Height - 4));
        e.Graphics.FillRectangle(Brushes.YellowGreen, ProgressBar);
        e.Graphics.DrawString($"0.{seconds.ToString("D2")}.{cents.ToString("D2")}", label1.Font, Brushes.White, rect, format);
    }
