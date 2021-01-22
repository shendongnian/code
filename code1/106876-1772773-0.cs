    class BackgroundDoerOfSomething : BackgroundWorker
    {
        string _SomeData;
        public string SomeResult { get; private set; }
        public BackgroundDoerOfSomething(string someData)
        {
            _SomeData = someData;
        }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            // do some processing, and then assign the result
            SomeResult = "some other data";
        }
    }
