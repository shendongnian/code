    public class MyControl : Control
    {
        private TimeSpan paintTime = 250;   // Time to paint, default=250ms
        private TimeSpan resizeTime = 100;  // Time to update layout, default=100ms
        protected override void OnPaint(PaintEventArgs pe)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Do your painting here, or call base.OnPaint
            sw.Stop();
            paintTime = sw.Elapsed;
        }
        protected override void OnResize(EventArgs e)
        {
            // The "Stop" is not redundant - it will force the timer to "reset"
            // if it is already running.
            resizeTimer.Stop();
            base.OnResize(e);
            resizeTimer.Interval =
                (int)(paintTime.TotalMilliseconds + resizeTime.TotalMilliseconds);
            resizeTimer.Start();
        }
        private void UpdateSize()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Resizing code goes here
            sw.Stop();
            resizeTime = sw.Elapsed;
        }
        private void resizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.Stop();
            UpdateSize();
        }
    }
