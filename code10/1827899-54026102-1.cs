    public class IssuerAuthorizationHandler : IAuthorizationHandler
    {
        private readonly IMyService _service;
        public IssuerAuthorizationHandler(IMyService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.User.FindFirst("iss") != null)
            {
                string issuer = context.User.FindFirst("iss").Issuer;
                // do issuer validation here
            }
            else
            {
                // fail the authentication
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
