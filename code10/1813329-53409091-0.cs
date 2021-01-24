	public class Service : IDisposable
	{
		private readonly BlockingCollection<WebServiceLogModel> _packets =
			new BlockingCollection<WebServiceLogModel>();
		private Task _task;
		private volatile bool _active;
		private static readonly TimeSpan WaitTimeout = TimeSpan.FromSeconds(1);
		
		public Service()
		{
			_active = true;
			_task = ExecTaskInternal();
		}
		
		public void Enqueue(WebServiceLogModel model)
		{
			_packets.Add(model);
		}
		
		public void Dispose()
		{
			_active = false;
		}
		
		private async Task ExecTaskInternal()
		{
			while (_active)
			{
				if (_packets.TryTake(out WebServiceLogModel model))
				{
					// TODO: whatever you need
				}
                else
                {
                    await Task.Delay(WaitTimeout);
                }
			}
		}
	}
	
	public class MyController : Controller
	{
		[HttpGet]
		[Route("abc")]
		public IActionResult GetData([FromServices] Service service)
		{
			// receive model form somewhere
			WebServiceLogModel model = FetchModel();
			// enqueue model
			service.Enqueue(model);
			// TODO: return what you need
		}
	}
