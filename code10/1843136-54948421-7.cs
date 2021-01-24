    public class AnotherGenericPreProcessCommand<TRequest> : IRequestPreprocessor<TRequest>
    {
    
                public ProcessFirstCommandHandlerDecorator()
                {
        
                }
        
                public Task Process(ProcessFirstCommand request, CancellationToken cancellationToken)
                {
                    Console.WriteLine("I'm generic aswell!");
                }
     }
