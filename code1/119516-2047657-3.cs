    public class Service : IService
    {
        private readonly ISomeDependency dep;
        public Service(ISomeDependency dep)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }
            this.dep = dep;
        }
        public ISomeDependency Dependency
        {
            get { return this.dep; }
        }
    }
