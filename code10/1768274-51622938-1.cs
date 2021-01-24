    public class ContextHelper {
        public static HttpContext GetHttpContext(string name = "validemail@test.com") {
            var identity = new GenericIdentity(name, "test");
            var contextUser = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext() {
                User = contextUser
            };
            return httpContext;
        }
    }
