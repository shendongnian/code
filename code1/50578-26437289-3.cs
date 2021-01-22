        private readonly ThreadSafeEventInvoker someEventWrapper = new ThreadSafeEventInvoker();
		public event Action SomeEvent
		{
			add { someEventWrapper.Add(value); }
			remove { someEventWrapper.Remove(value); }
		}
		public void RaiseSomeEvent()
		{
			someEventWrapper.Raise();
		}
