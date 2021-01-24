    public interface IHttpContextAccessor {
        HttpContextBase HttpContext { get; }
    }
    public class HttpContextProvider : IHttpContextAccessor {
        public virtual HttpContextBase HttpContext {
            get {
                return new HttpContextWrapper(HttpContext.Current);
            }
        }
    }
    
