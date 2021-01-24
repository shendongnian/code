    public class AuthorizationHeaderBinder : IModelBinder
    {
        const string DEFAULT_ACCESS_TOKEN_AUTH_HEADER_PREFIX = "accessToken";
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
            var modelName = bindingContext.BinderModelName;
            if (string.IsNullOrEmpty(modelName)) { modelName = DEFAULT_ACCESS_TOKEN_AUTH_HEADER_PREFIX; }
            var authorization = bindingContext.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (String.IsNullOrWhiteSpace(authorization)) {
                return Task.CompletedTask;
            }
            if (!authorization.StartsWith(modelName, StringComparison.OrdinalIgnoreCase)) {
                return Task.CompletedTask;
            }
            var token = authorization.Substring(modelName.Length).Trim();
            bindingContext.Result = ModelBindingResult.Success(new AccessTokenAuthorizationHeader() {
                TokenValue =token,
            });
            return Task.CompletedTask;
        }
    }
