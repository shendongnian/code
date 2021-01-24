    public class GenericPreProcessCommand<TRequest> : IRequestPreprocessor<TRequest>
    {
    
                public ProcessFirstCommandHandlerDecorator()
                {
        
                }
        
                public Task Process(ProcessFirstCommand request, CancellationToken cancellationToken)
                {
                    Console.WriteLine("I'm generic!");
                }
     }
