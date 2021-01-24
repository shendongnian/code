    public interface IHttpContextAccessor {
        HttpContextBase HttpContext { get; }
    }
    public class HttpContextProvider : IHttpContextAccessor {
        private Lazy<HttpContextWrapper> _httpContext;
        public HttpContextProvider() {
            _httpContext = 
            new Lazy<HttpContextWrapper>(() => new HttpContextWrapper(HttpContext.Current));
        }
        public virtual HttpContextBase HttpContext {
            get {
                return _httpContext.Value;
            }
        }
    }
    
