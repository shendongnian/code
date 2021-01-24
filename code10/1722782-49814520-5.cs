    public class JobController : Controller
    {
        private readonly TasksToRun _tasks;
        public JobController(TasksToRun tasks) => _tasks = tasks;
        public IActionResult PostJob()
        {
            var settings = CreateTaskSettings();
            _tasks.Enqueue(settings);
            return Ok();
        }
    }
