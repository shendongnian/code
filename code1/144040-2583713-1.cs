    public static class LabelExtensions
    {
        public static Label BlinkText(this Label label, int duration)
        {
            Timer timer = new Timer();
            timer.Interval = duration;
            timer.Tick += (sender, e) =>
                {
                    timer.Stop();
                    label.Font = new Font(label.Font, label.Font.Style ^ FontStyle.Bold);
                };
            label.Font = new Font(label.Font, label.Font.Style | FontStyle.Bold);
            timer.Start();
            return label;
        }
    }
