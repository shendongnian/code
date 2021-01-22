	public class ProducerConsumer
	{
		private ManualResetEvent _ready;
		private Queue<Delegate> _queue; 
		private Thread _consumerService;
		
		// Note: if you get a thread-safe queue like
		// Java's BlockingQueue, then you can remove the
		// _sync object and have a true lock-free/wait-free
		// system that is completely data driven.
		private static Object _sync = new Object();
		
		public ProducerConsumer(Queue<Delegate> queue)
		{
			lock (_sync)
			{
				// Note: I would recommend that you don't even
				// bother with taking in a queue.  You should be able
				// to just instantiate a new Queue<Delegate>()
				// and use it when you Enqueue.  There is nothing that
				// you really need to pass into the constructor.
				_queue = queue;
				_ready = new ManualResetEvent(false);
				_consumerService = new Thread(Run);
				_consumerService.IsBackground = true;
				_consumerService.Start();
			}
		}
		
		public override void Enqueue(Delegate value)
		{
			lock (_sync)
			{
				_queue.Enqueue(value);
				_ready.Set();
			}
		}
		// The consumer blocks until the producer puts something in the queue.
		private void Run()
		{
			Delegate query;
			try
			{
				while (true)
				{
					_ready.WaitOne();
					lock (_sync)
					{
						if (_queue.Count > 0)
						{
							query = _queue.Dequeue();
							query.DynamicInvoke(null);
						}
						else
						{
							_ready.Reset();
							continue;
						}
					}
				}
			}
			catch (ThreadInterruptedException)
			{
				_queue.Clear();
				return;
			}
		}
		protected override void Dispose(bool disposing)
		{
			lock (_sync)
			{
				if (_consumerService != null)
				{
					_consumerService.Interrupt();
				}
			}
			base.Dispose(disposing);
		}
		
		
	}
