    public interface IQueueService
    {
        void Push(Reload reload);
    }
    public IEnumerable<Reload> GetStandardizedReloads()
    {
        return _queueService.Items();  
    }
    public IEnumerable<Request> GetRequests()
    {
        return _requestRepository.GetAll();
    }
