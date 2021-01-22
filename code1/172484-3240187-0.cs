        private static readonly AutoResetEvent _Next = new AutoResetEvent(true);
        private static Timer _NextTimer;
        private static void SendMessages(IEnumerable<Message> messages)
        {
            if (_NextTimer == null)
                InitializeTimer();
            Parallel.ForEach(
                messages,
                m =>
                {
                    _Next.WaitOne();
                    // Do something
                }
                );
        }
        private static void SetNext(object state)
        {
            _Next.Set();
        }
