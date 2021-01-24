    public static class QtTimer
    {
        public static async void SingleShot(int timeMs, Action lambda)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(timeMs)).ContinueWith(_ => lambda());
        }
    }
