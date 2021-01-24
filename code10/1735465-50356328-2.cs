    public class ProducerBufferConsumerService
    {
        private List<Task> _producerTasks;
        private List<Task> _consumerTasks;
        private ServiceClient _serviceClient;
        private Service _service;
    
        public ProducerBufferConsumerService(ServiceClient serviceClient, Service service)
        {
            _serviceClient = serviceClient;
            _service = service;
    
            _producerTasks = new List<Task>();
            _consumerTasks = new List<Task>();
        }
    
        public void Process(CancellationToken token)
        {
            var buffer = new BlockingCollection<IServiceMessage>(1000);
            _producerTasks.Add(Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    var message = await _serviceClient.GetAsync();
                    buffer.Add(message, token);
                }
    
                buffer.CompleteAdding();
            }));
    
            _consumerTasks.Add(Task.Run(async () =>
            {
                while (!token.IsCancellationRequested && !buffer.IsAddingCompleted)
                {
                    var message = buffer.Take(token);
                    await _service.ProcessAsync(message);
                }
            }));
        }
    
        public void WaitForCompletion()
        {
            Task.WaitAll(_producerTasks.ToArray(), 10000);
            Task.WaitAll(_consumerTasks.ToArray(), 10000);
        }
    }
