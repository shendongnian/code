         public class HomeController : Controller
        {
        private readonly TimeHub _timeHub;
        public HomeController(TimeHub timeHub)
        {
            _timeHub = timeHub;
        }
        public IActionResult Index()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        await _timeHub.UpdateTime(DateTime.Now.ToShortDateString());
                        Thread.Sleep(2000);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            });
            return View();
        }
