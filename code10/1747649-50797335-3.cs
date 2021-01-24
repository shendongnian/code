    public class SomeClass
    {
        private readonly NotifyService _service;
        public SomeClass(NotifyService service)
        {
            _service = service;
        }
    
        public Task Send(string message)
        {
            return _service.SendNotificationAsync(message);
        }
    }
