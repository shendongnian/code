    public class PreProcessFirstCommand : IRequestPreprocessor<ProcessFirstCommand>
    {
    
            public ProcessFirstCommandHandlerDecorator()
            {
    
            }
    
            public Task Process(ProcessFirstCommand request, CancellationToken cancellationToken)
            {
                Console.WriteLine("I ran before the handler");
            }
    }
