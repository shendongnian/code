    class Bar : IBar
    {
        private IEnumerable<IFoo> Foos { get; set; }
        internal CountdownEvent FooCountdown;
        public Bar(IEnumerable<IFoo> foos)
        {
            Foos = foos;
        }
        public void Start()
        {
            FooCountdown = new CountdownEvent(foo.Count);
            foreach(var foo in Foos)
            {
                Task.Factory.StartNew(() =>
                {
                    foo.Start();
                    // once a worker method completes, we signal the countdown
                    FooCountdown.Signal();
                });
            }
        }
    }
