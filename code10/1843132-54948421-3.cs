    public class ProcessFirstCommandHandler : IRequestHandler<ProcessFirstCommand, bool>
    {
        public Task<bool> Handle(ProcessFirstCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("I'm inside the handler");
    
            return Task.FromResult(true);
        }
    }
