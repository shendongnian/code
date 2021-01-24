    public class CoolJob : IMyJob
    {
        private readonly IJobRepository _repo;
        public CoolJob(IJobRepository repo) => _repo = repo;
        public void DoWork() => ...
    }
