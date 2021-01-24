    public interface IServiceManager
    {
        IEnumerable<ServiceRequests> GetAllServiceRequests();
      
        Service GetService(string serviceId);
    }
