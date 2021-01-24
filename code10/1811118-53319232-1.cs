    public static class QtTimer
    {
        public static void SingleShot(int timeMs, Action lambda)
        {
            var _ = Task.Delay(TimeSpan.FromMilliseconds(timeMs)).ContinueWith(_ => lambda());
        }
    }
