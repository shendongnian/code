    private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus) {
        validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
    }
    
    // This method must be thread-safe since it is called by the caching module.
    protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext) {
        if (httpContext == null) {
            throw new ArgumentNullException("httpContext");
        }
    
        bool isAuthorized = AuthorizeCore(httpContext);
        return (isAuthorized) ? HttpValidationStatus.Valid : HttpValidationStatus.IgnoreThisRequest;
    }
