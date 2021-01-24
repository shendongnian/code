    [ApiController]
	[Produces("application/json")]
	public class EventHandlerController : Controller
	{
		private readonly IHubContext<NotificationHub> _hubContext;
		public EventGridEventHandlerController(IHubContext<NotificationHub> hubContext)
		{
			_hubContext = hubContext;
		}
		[HttpPost]
		[Route("api/EventHandler")]
		public IActionResult Post([FromBody]object request)
		{
			object[] args = { request };
			_hubContext.Clients.All.SendCoreAsync("SendMessage", args);
			Console.WriteLine(truck);
		
			return Ok();
		}
	}
