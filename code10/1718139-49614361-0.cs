    public class MyCustomMiddleware : OwinMiddleware {
        public MyCustomMiddleware(OwinMiddleware next)
            : base(next) {
        }
        public override async Task Invoke(IOwinContext context) {
            var request = context.Request;
            var headers = request.Headers;
            var headerKey = "X-TYPE";
            // custome header
            if (headers.ContainsKey(headerKey)) {
                var xType = headers[headerKey];
                //...
            }
            // continue pipeline
            await Next.Invoke(context);
            //...
        }
    }
