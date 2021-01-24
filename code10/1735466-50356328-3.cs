    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var filters = new List<string>() { "A", "B", "C", "D" };
            var service = new Service();
            var serviceClient = new ServiceClient();
            var partitioningService = new PartitioningService(serviceClient, service);
            var processingTask = Task.Run(() => partitioningService.Process(filters, cts.Token));
    
    
            Console.WriteLine("Press any key to shutdown");
            Console.ReadKey();
    
            cts.Cancel();
            processingTask.Wait(10000);
        }
    }
    public interface IServiceMessage
    {
        string Message { get; }
        Guid Id { get; set; }
    }
    
    public class ServiceMessage : IServiceMessage
    {
        public string Message { get; set; }
        public Guid Id { get; set;  }
    }
    
    public class RoutedMessage
    {
        public IServiceMessage Message { get; set; }
        public int PartitionId { get; set; }
    }
    
    public class PartitioningService
    {
        private ServiceClient _serviceClient;
        private Service _service;
    
        public PartitioningService(ServiceClient serviceClient, Service service)
        {
            _serviceClient = serviceClient;
            _service = service;
        }
    
        public void Process(List<string> filters, CancellationToken token)
        {
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            Func<IServiceMessage, RoutedMessage> partitioner = x => new RoutedMessage
                { 
                    Message = x,
                    PartitionId = x.Id.GetHashCode() / 1000000000
            };
    
            var partitionerBlock = new TransformBlock<IServiceMessage, RoutedMessage>(partitioner);
            var actionBlock1 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock2 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock3 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock4 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock5 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock6 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock7 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock8 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
            var actionBlock9 = new ActionBlock<RoutedMessage>(async (RoutedMessage msg) => await _service.ProcessAsync(msg));
    
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == -4);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == -3);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == -2);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == -1);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == 0);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == 1);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == 2);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == 3);
            partitionerBlock.LinkTo(actionBlock1, linkOptions, msg => msg.PartitionId == 4);
    
            var tasks = new List<Task>();
            foreach (var filter in filters)
            {
                tasks.Add(Task.Run(async () =>
                    {
                        Guid filterId = Guid.NewGuid();
    
                        while (!token.IsCancellationRequested)
                        {
                            var message = await _serviceClient.GetAsync(filter);
                            message.Id = filterId;
                            await partitionerBlock.SendAsync(message);
                        }
                    }));
            }
    
            while (!token.IsCancellationRequested)
                Thread.Sleep(100);
                            
            partitionerBlock.Complete();
            actionBlock1.Completion.Wait();
            actionBlock2.Completion.Wait();
            actionBlock3.Completion.Wait();
            actionBlock4.Completion.Wait();
            actionBlock5.Completion.Wait();
            actionBlock6.Completion.Wait();
            actionBlock7.Completion.Wait();
            actionBlock8.Completion.Wait();
            actionBlock9.Completion.Wait();
    
            Task.WaitAll(tasks.ToArray(), 10000);
        }
    }
