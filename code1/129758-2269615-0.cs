    class JobAttribute : ActionFilterAttribute {
        [Inject]
        public IUserSession UserSession
        { set; private get; }
    
        [Inject]
        public IJobRepository JobRepository
        { set; private get; }
    }
