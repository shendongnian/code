    [RoutePrefix("")]
    public class HomeController : ApiController
    {
        [Route(""), HttpGet]
        public void Get()
        {
            Hangfire.BackgroundJob.Enqueue(() => Tasks.DoIt("test"));
        }
    }
    public static class Tasks
    {
        public static void DoIt(string s)
        {
            Console.WriteLine(s);
        }
    }
