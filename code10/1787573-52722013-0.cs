    public class ProcessHandler : AsyncRequestHandler<IntermediateDocument.Command>
    {
        // ...ctor 
        protected async override Task Handle(Command request, CancellationToken cancellationToken)
        {
            // inside this using every component asking for an
            // IEFUnitOfWork will get the same instance 
            using (var unitOfWorkScope = _scope.BeginLifetimeScope("UnitOfWork"))
            {
                foreach (var transaction in request.Transactions)
                {
                    // we don't need this inner scope to be tagged, AFAICT
                    // so probably "Operation" could be omitted.
                    using (var scope = unitOfWorkScope.BeginLifetimeScope("Operation"))
                    {
                        // I'm not sure what a "mediator" is, I'm just copying the example code
                        var mediator = scope.Resolve<IMediator>();
                        await mediator.Send(...do something with transaction);
                    } // here mediator will be disposed, once for each transaction instance
                }
            } // here everything resolved inside unitOfWorkScope will be disposed (and possibly committed).
        }
    }
