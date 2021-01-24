    using Next = Func<IOwinContext, Task>;
    public class MyMiddleware {
        Next next;
        public MyMiddleware(Next next) {
            this.next = next;
        }
        public async Task Invoke(IOwinContext context) {
            //The middleware is supposed to look at the cookies of the incoming request, 
            var request = context.Request;
            var authenticated = request.User.Identity.IsAuthenticated;
            var cookies = request.Cookies;
            if (cookies["cookie-name"] != null) {
                // 1. check for existence of a cookie on the incoming request. 
                //if the cookie exists, use its value to set a header, 
                //so that the pipline after this component thinks the header was always present.
                request.Headers.Append("header-name", "header-value");
            }
            //2. call the next component.
            await next.Invoke(context);
            //3. on the way out, check for some conditions, and possibly set a cookie value.
            if (authenticated) {
                context.Response.Cookies.Append("cookie-name", "cookie-value");
            }
        }
    }
