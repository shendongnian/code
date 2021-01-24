    public class MyMiddlewareClass : OwinMiddleware
    {
        // 5 secs is ok for testing, you might want to increase this
        const int WAIT_MAX_MS = 5000;
        public MyMiddlewareClass(OwinMiddleware next) : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            using (var source = CancellationTokenSource.CreateLinkedTokenSource(
                context.Request.CallCancelled))
            {
                source.CancelAfter(WAIT_MAX_MS);
                // combined "client disconnected" and "it takes too long" token
                context.Set("RequestTerminated", source.Token);
                await Next.Invoke(context);
            }
        }
    }
