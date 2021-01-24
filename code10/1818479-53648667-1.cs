        public class AuthorizeMultiplePolicyFilter: IAsyncAuthorizationFilter
        {
        private readonly IAuthorizationService _authorization;
        public string _policies { get; private set; }
        public bool _isAll { get; set; }
        public AuthorizeMultiplePolicyFilter(string policies, bool IsAll,IAuthorizationService authorization)
        {
            _policies = policies;
            _authorization = authorization;
            _isAll = IsAll;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policys = _policies.Split(";").ToList();
            if (_isAll)
            {
                foreach (var policy in policys)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                    if (!authorized.Succeeded)
                    {
                        context.Result = new ForbidResult();
                        return;
                    }
                }
            }
            else
            {
                foreach (var policy in policys)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                    if (authorized.Succeeded)
                    {
                        return;
                    }
                }
                context.Result = new ForbidResult();
                return;
            }
        }
        }
