    // can be any other type not necessarily `string`
    public class EmptyQuery : IRequest<string>{...}
    
    public class EmptyQueryHandler : IRequestHandler<EmptyQuery, string>
    {
        public Task<string> Handle(EmptyQuery notification, CancellationToken cancellationToken)
        {
            return Task.FromResult("Sample response");
        }
    }
