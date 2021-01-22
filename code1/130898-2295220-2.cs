	public class ProducerConsumer
	{
		private bool _canEnqueue;
		private ManualResetEvent _ready;
		private Queue<Delegate> _queue; 
		private Thread _consumerService;
		
		private static Object _sync = new Object();
		private static ManualResetEvent _wait = new ManualResetEvent(false);
		
		public ProducerConsumer()
		{
			lock (_sync)
			{
				_queue = new Queue<Delegate> _queue;
				_canEnqueue = true;
				_ready = new ManualResetEvent(false);
				_consumerService = new Thread(Run);
				_consumerService.IsBackground = true;
				_consumerService.Start();
			}
		}
		public bool Enqueue(Delegate value)
		{
			lock (_sync)
			{
				// Don't allow anybody to enqueue
				if( _canEnqueue )
				{
					_queue.Enqueue(value);
					_ready.Set();
					return true;
				}
			}
			// Whoever is calling Enqueue should try again later.
			return false;
		}
		// The consumer blocks until the producer puts something in the queue.
		private void Run()
		{
			try
			{
				while (true)
				{
					// Wait for a query to be enqueued
					_ready.WaitOne();
					
					// Process the query
					lock (_sync)
					{
						if (_queue.Count > 0)
						{
							Delegate query = _queue.Dequeue();
							query.DynamicInvoke(null);
						}
						else
						{
							_canEnqueue = true;
							_ready.Reset();
							_wait.Set();
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
		// Block your queue from enqueuing, return null
		// if the queue is already empty.
		public ManualResetEvent BlockQueue()
		{
			lock(_sync)
			{
				if( _queue.Count > 0 )
				{
					_canEnqueue = false;
					_wait.Reset();
				}
				else
				{
					// You need to tell the caller that they can't
					// block your queue while it's empty. The caller
					// should check if the result is null before calling
					// WaitOne().
					return null;
				}
			}
			return _wait;
		}
		
		protected override void Dispose(bool disposing)
		{
			lock (_sync)
			{
				if (_consumerService != null)
				{
					_consumerService.Interrupt();
					// Set wait when you're disposing the queue
					// so that nobody is left with a lingering wait.
					_wait.Set();
				}
			}
			base.Dispose(disposing);
		}
	}
