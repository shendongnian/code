    public class ServiceClient
    {
        public async Task<IServiceMessage> GetAsync(string filter)
        {
            await Task.Yield();
            return new ServiceMessage() { Message = Guid.NewGuid().ToString() };
        }
    }
    
    public class Service
    {
        public async Task ProcessAsync(IServiceMessage message)
        {
            // do something with it
            await Task.Delay(10);
        }
    }
    public interface IServiceMessage
    {
        string Message { get; }
    }
    
    public class ServiceMessage : IServiceMessage
    {
        public string Message { get; set; }
    }
