    public class HostedServiceOneDecorator : MyHostedServiceDecorator
    {
        public HostedServiceOneDecorator(MyHostedServiceDecorator next) : base(next)
        {
        }
        protected override async Task StartAsyncInternal(CancellationToken token)
        {
            Console.Write("This is my decorated start async!");
        }
        protected override async Task StopAsyncInternal(CancellationToken token)
        {
            Console.Write("This is my decorated stop async!");
        }
    }
