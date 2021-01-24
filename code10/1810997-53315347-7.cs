    public class ServiceManager : IServiceManager
    {
        public ApplicationDbContext _dbContext { get; set; }
    
        public ServiceRequest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public IEnumerable<ServiceRequests> GetAllServiceRequests()
            => _dbContext.ServiceRequests.OrderBy(r => r.Id);
    
        public Service GetService(string serviceId)
            => !string.IsNullOrEmpty(serviceId) 
                   ? _dbContext.Services.SingleOrDefault(x => x.Id == serviceId) : null;
    }
