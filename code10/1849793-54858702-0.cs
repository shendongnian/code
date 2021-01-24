        public interface IUserService
        {
            void RegisterUser();
        }
        public class UserService : IUserService
        {
            private IUrlHelper _urlHelper;
            private HttpRequest _request;
            public UserService(IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor)
            {
                _urlHelper = urlHelper;
                _request = httpContextAccessor.HttpContext.Request;
            }
            public void RegisterUser()
            {
                var callbackUrl = _urlHelper.EmailConfirmationLink("user.Email", "token", _request.Scheme);
                //throw new NotImplementedException();
            }
        }
