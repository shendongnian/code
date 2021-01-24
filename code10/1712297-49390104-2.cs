    public class MyClass
    {
        private readonly IHub hub;
    
        public MyClass(IHub hub)
        {
            this.hub = hub;
            hub.OnBroadcastAction += OnBroadcast;
        }
    
        public Task Send(string message)
        {
            await hub.Send(message);
        }
    
        private void OnBroadcast(string message)
        {
            Console.WriteLine(message);
        }
    }
