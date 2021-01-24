    public class MapAndContinueMiddleware : OwinMiddleware {
        private readonly MapOptions options;
        public MapAndContinueMiddleware(OwinMiddleware next, MapOptions options)
            : base(next) {
            this.options = options;
        }
        public async override Task Invoke(IOwinContext context) {
            PathString path = context.Request.Path;
            PathString remainingPath;
            if (path.StartsWithSegments(options.PathMatch, out remainingPath)) {
                // Update the path
                PathString pathBase = context.Request.PathBase;
                context.Request.PathBase = pathBase + options.PathMatch;
                context.Request.Path = remainingPath;
                //call branch delegate
                await this.options.Branch(context.Environment);
                context.Request.PathBase = pathBase;
                context.Request.Path = path;
            }
            // call next delegate
            await this.Next.Invoke(context);
        }
    }
