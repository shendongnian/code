        [Route("api/[controller]/[action]")]
    public class XmlController : Controller
    {
        private readonly ITimerService _timerService;
        public XmlController(ITimerService timerService)
        {
            //Injected in
            _timerService = timerService;
        }
        
        [HttpGet]
        public IActionResult ProccessXML(object someXMLObject)
        {
            _timerService.StopTimer();
            SomeMethodWithXml(someXMLObject)
            //Reset Timer
            _timerService.StartTimer();
            return Ok();
        }
    }
