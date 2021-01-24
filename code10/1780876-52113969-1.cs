    [RoutePrefix("")]
    public class HomeController : ApiController
    {
        [Route(""), HttpGet]
        public void Get()
        {
            Hangfire.BackgroundJob.Enqueue(() => Tasks.DoIt("test"));
            Hangfire.BackgroundJob.Schedule(() => Tasks.InitializeJobs(), TimeSpan.FromSeconds(5));
        }
    }
    public static class Tasks
    {
        public static void DoIt(string s)
        {
            Console.WriteLine(s);
        }
        public static void InitializeJobs()
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
