    public class Counter
    {
        private readonly TimeSpan initialDelay, incrementDelay;
        private readonly int maxCount;
        private Timer timer;
        private int count;
        public Counter(TimeSpan initialDelay, TimeSpan incrementDelay, int maxCount)
        {
            this.maxCount = maxCount;
            this.initialDelay = initialDelay;
            this.incrementDelay = incrementDelay;
        }
        public void Start(Action<int> tickBehavior)
        {
            if (timer != null)
            {
                Timer temp = timer;
                timer = null;
                temp.Dispose();
            }
            timer = new Timer(() =>
                {
                    tickBehavior(count++);
                    if (count > maxCount) timer.Dispose();
                }, null, initialDelay, incrementDelay);
        }
    }
