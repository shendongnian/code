    class StartableList<T> : List<T>, IStartable where T : IStartable
    {
        public StartableList(IEnumerable<T> arr)
            : base(arr)
    	{
    	}
    
        public void Start()
        {
            foreach (IStartable s in this)
            {
                s.Start();
            }
        }
    
        public void Stop()
        {
            foreach (IStartable s in this)
            {
                s.Stop();
            }
        }
    }
