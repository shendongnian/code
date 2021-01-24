    public class ProcessFirstCommandHandler : IRequestHandler<ProcessFirstCommand, bool>
    {
        public Task<bool> Handle(ProcessFirstCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Inside Process First Command Handler");
    
            return Task.FromResult(true);
        }
    }
