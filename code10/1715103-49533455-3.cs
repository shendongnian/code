    public class SetupMiddleware : OwinMiddleware
    {
        public const string EnvironmentKey = "WindsorOwinScope";
        public SetupMiddleware(OwinMiddleware next) : base(next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
        }
        public override async Task Invoke(IOwinContext context)
        {
            ILifetimeScope lifetimeScope = new DefaultLifetimeScope();
            
            try
            {
                context.Environment[EnvironmentKey] = lifetimeScope;
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                context.Environment.Remove(EnvironmentKey);
                lifetimeScope.Dispose();
            }
        }
    }
