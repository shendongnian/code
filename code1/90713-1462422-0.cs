	delegate void CompletedRequest(Request req);
	class Processor : ITrackCompletion
	{
		//I need to maintain this list so that when the service stops I can cleanly close down
		List<Request> requests = new List<Request>();
		public void NewRequest(string data)
		{
			lock(requests)
				request.Add(new Request(data), Complete);
		}
		public void Complete(Request req)
		{
			lock (requests)
				requests.Remove(req);
		}
		public void Dispose()
		{
			//Cleanup each request
			foreach (Request request in requests.ToArray())
			{
				request.Dispose();
			}
		}
	}
	class Request
	{
		Thread thread;
		bool terminate;
		public Request(string data, CompletedRequest complete)
		{
			try
			{
				while (true)
				{
					//Do some work
					Thread.Sleep(1000);
					if (doneWorking)
						break;
					if (terminate)
						return;
				}
			}
			finally
			{
				//We're done.  If I return this thread stops.  But how do I properly remove this Request instance from the Processor.requests list?
				complete(this);
			}
		}
		void Dispose()
		{
			terminate = true;
			thread.Join();
		}
	}
