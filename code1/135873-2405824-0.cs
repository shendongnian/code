    public claass JobsController : Controller 
    {
        public IList<JobDto> Index(JobSearchCriteria criteria)
        { 
            IList<JobDto> jobs = _jobs.Find(criteria);
            //... 
        }
    }
