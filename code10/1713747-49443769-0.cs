    public class AccessTokenProvider : Microsoft.Owin.Security.Infrastructure.AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.SetToken("yourtoken");
            base.Create(context);
        }
    }
