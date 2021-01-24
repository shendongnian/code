    public class IsAliveHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Bootstrapper.Container.GetInstance<IsAliveService>().Process(context);
        }
    }
