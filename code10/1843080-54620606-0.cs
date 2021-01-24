    public class HeaderService : IHeaderService {
        public string RealHeaderValueFromHttpRequest() {
            return HttpContext.Current.Request.Headers["RealHeaderValueFromHttpRequest"];
        }
    }
