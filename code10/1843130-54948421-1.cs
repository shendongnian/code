    public class PreProcessFirstCommand : IRequestPreprocessor<ProcessFirstCommand>
    {
    
            public ProcessFirstCommandHandlerDecorator()
            {
                
            }
    
            public Task Process(ProcessFirstCommand request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Inside Process First Command Handler Decorator");
            }
    }
