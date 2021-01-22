    public static class LabelExtensions
    {
        public static List<WeakReference> _References = new List<WeakReference>();
        public static Label BlinkText(this Label label, int duration)
        {
            Timer timer = new Timer();
            _References.Add(new WeakReference(timer));
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
