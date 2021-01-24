     private BlockingCollection<WebPages> _concurrentWebPageList = new BlockingCollection<WebPages>(new ConcurrentQueue<WebPages>(), 1000);
        //private static ConcurrentQueue<WebPages> _concurrentWebPageList = new ConcurrentQueue<WebPages>();
        public void IncreaseEngineFlow(WebPages page)
        {
            _concurrentWebPageList.Add(page);
        }
        public WebPages DecreaseEngineFlow()
        {
            return _concurrentWebPageList.Take();
        }
        public void ProcessExportEngineFlow()
        {
            while(!_concurrentWebPageList.IsCompleted)
            {
                WebPages page = null;
                try
                {
                    page = _concurrentWebPageList.Take();
                }
                catch (InvalidOperationException) { }
                if(page != null)
                {
                    Console.WriteLine(page.URL);
                }
            }
        }
        public bool GetEngineState()
        {
            return _concurrentWebPageList.IsCompleted;
        }
        public void SetEngineCompleted()
        {
            _concurrentWebPageList.CompleteAdding();
        }
