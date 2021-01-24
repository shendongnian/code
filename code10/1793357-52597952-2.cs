    public class ProcessController : Controller
    {
        // GET: Processes
        public ViewResult List()
        {
            var processList = from p in Process.GetProcesses()
                              select p;
            ViewData["Model"] = processList.ToList();
            return View();
        }
    }
