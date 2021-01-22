    public SelectiveService : IMyService
    {
        private readonly IMyService normalService;
        private readonly IMyService adminService;
        public SelectiveService(IMyService normalService, IMyService adminService)
        {
            if (normalService == null)
            {
                throw new ArgumentNullException("normalService");
            }
            if (adminService == null)
            {
                throw new ArgumentNullException("adminService");
            }
            this.normalService = normalService;
            this.adminService = adminService;
        }
        public List<Foo> All()
        {
            if(Thread.CurrentPrincipal.IsInRole(MyRoles.Administrators))
            {
                return this.adminService.All();
            }
            return this.normalService.All();
        }
    }
