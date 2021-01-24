    class Events {
        public event Action<string> MessageArrived;
        Timer _timer;
        public void Start()
        {
            Console.WriteLine("Timer starting");
            int i = 0;
            _timer = new Timer(_ => {
                this.MessageArrived?.Invoke(i.ToString());
                i++;
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        public void Stop() {
            _timer?.Dispose();
            Console.WriteLine("Timer stopped");
        }
    }
