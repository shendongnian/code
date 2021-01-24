    public class SomeController : Controller
    {
        private readonly IWatcher _watcher;
        public SomeController(IWatcher watcher)
        {
			_watcher = watcher;
        }	
	}	
