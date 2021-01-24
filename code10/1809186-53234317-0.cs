    public interface IJob
    {
        void Do();
    }
    public class JobOne : IJob
    {
        public void Do()
        {
            // do something
        }
    }
    public class JobTwo : IJob
    {
        public void Do()
        {
            // do something different
        }
    }
    public class DoNothing : IJob
    {
        public void Do() { }
    }
    public class JobRunner
    {
        private readonly Dictionary<string IJob> _jobs;
        private readonly IJob _doNothing;
        public JobRunner()
        {
            _jobs = new Dictionary<string, IJob>
            {
                { "one", new JobOne() },
                { "two", new JobTwo() },
            };
            _doNothing = new DoNothing();
        }
        public void Run(string jobKey)
        {
            _jobs.GetValueOrDefault(jobkey, _doNothing).Do();
        }
    }
