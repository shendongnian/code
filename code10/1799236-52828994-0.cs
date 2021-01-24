    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private readonly IAccessTokenServices _accessTokenServices;
        private readonly IPermissionServices _permissionServices;
        private readonly IAuditLogServices _auditLogServices;
        private IConfiguration _config;
        public AuthorizationRequiredAttribute(IAccessTokenServices accessTokenServices, IPermissionServices permissionServices,
            IAuditLogServices auditLogServices,IConfiguration config)
        {
            _accessTokenServices = accessTokenServices;
            _config = config;
            _permissionServices = permissionServices;
            _auditLogServices = auditLogServices;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (context.HttpContext.Request.Headers.ContainsKey(Constants.HttpHeaders.Token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadToken(context.HttpContext.Request.Headers[Constants.HttpHeaders.Token])
                        as JwtSecurityToken;
                    var expireDate = Convert.ToDateTime(token.Claims.First(claim => claim.Type == Constants.JwtClaims.ExpiresOn).Value);
                    if (context.HttpContext.Request.Method == WebRequestMethods.Http.Get)
                    {
                        if (expireDate < DateTime.Now)
                        {
                            context.Result = new UnauthorizedResult();
                        }
                    }
                    else
                    {
                        
                        var accessToken = _accessTokenServices
                            .Details(x => x.Token == context.HttpContext.Request.Headers[Constants.HttpHeaders.Token]);
                        if (accessToken != null)
                        {
                            if (accessToken.ExpiresOn < DateTime.Now)
                            {
                                _accessTokenServices.Delete(accessToken);
                                context.Result = new UnauthorizedResult();
                            }
                            else
                            {
                                var userId = Convert.ToInt32(token.Claims.First(claim => claim.Type == Constants.JwtClaims.UserId).Value);
                                var userTypeId = Convert.ToInt32(token.Claims.First(claim => claim.Type == Constants.JwtClaims.UserTypeId).Value);
                                if (accessToken == null)
                                {
                                    context.Result = new UnauthorizedResult();
                                }
                                else if (!_permissionServices.IsPermissionExist(context.HttpContext.Request.Path.ToString(), userTypeId))
                                {
                                    context.Result = new StatusCodeResult((int)HttpStatusCode.NotAcceptable);
                                }
                                else
                                {
                                    
                                    _auditLogServices.Save(context.HttpContext.Request.Path.ToString(), userId);
                                    accessToken.ExpiresOn = DateTime.Now.AddMinutes(Convert.ToInt16(_config["Jwt:ExpiresOn"]));
                                    _accessTokenServices.UpdateExpireTime(accessToken);
                                }
                            }
                        }
                        else
                        {
                            context.Result = new UnauthorizedResult();
                        }
                    }
                }
                else
                {
                    context.Result = new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestResult();
            }
            base.OnActionExecuting(context);
        }
    }
