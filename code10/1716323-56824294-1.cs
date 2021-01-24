    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHostedService listenerService;
        public ValuesController(IHostedService listenerService)
        {
            this.listenerService = listenerService;
        }
    }
