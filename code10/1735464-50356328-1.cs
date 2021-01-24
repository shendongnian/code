    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var service = new Service();
            var serviceClient = new ServiceClient();
            var processor = new ProducerConsumerService(serviceClient, service);
            processor.Process("A", cts.Token);
            processor.Process("B", cts.Token);
            processor.Process("C", cts.Token);
            processor.Process("D", cts.Token);
    
            Console.WriteLine("Press any key to shutdown");
            Console.Read();
    
            cts.Cancel();
            processor.WaitForCompletion();
        }
    }
    public class ProducerConsumerService
    {
        private List<Task> _processTasks;
        private ServiceClient _serviceClient;
        private Service _service;
    
        public ProducerConsumerService(ServiceClient serviceClient, Service service)
        {
            _serviceClient = serviceClient;
            _service = service;
    
            _processTasks = new List<Task>();
        }
    
        public void Process(string filter, CancellationToken token)
        {
            _processTasks.Add(Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    var message = _serviceClient.Get(filter);
                    _service.Process(message);
                }
            }));
        }
    
        public void WaitForCompletion()
        {
            Task.WaitAll(_processTasks.ToArray(), TimeSpan.FromSeconds(10));
        }
    }
