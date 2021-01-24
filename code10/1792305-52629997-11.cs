    public class MapAndContinueMiddleware : OwinMiddleware {
        public MapAndContinueMiddleware(OwinMiddleware next, MapOptions options)
            : base(next) {
            this.Options = options;
        }
        public MapOptions Options { get; private set; }
        public async override Task Invoke(IOwinContext context) {
            if (context.Request.Path.StartsWithSegments(this.Options.PathMatch)) {
                //call branch delegate
                await this.Options.Branch(context.Environment);
            }
            // call next delegate
            await this.Next.Invoke(context);
        }
    }
