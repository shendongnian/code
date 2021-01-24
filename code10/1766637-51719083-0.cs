    public void OnAuthorization(AuthorizationFilterContext actionContext)
    {
      const string secretTokenName = "SecretToken";
      const string merchentKeyName = "MerchantKey";
      bool isValid = false;
      if (!actionContext.Filters.Any(item => item is IAllowAnonymousFilter))
        {
         CPServiceResponse response = new CPServiceResponse();
         var secretToken = actionContext.HttpContext.Request.Headers[secretTokenName].FirstOrDefault();
         var merchentKey = actionContext.HttpContext.Request.Headers[merchentKeyName].FirstOrDefault();
          isValid = this.IsValidMerchant(merchentKey, secretToken,_productCode);
           if (isValid == false)
            {
              response.Status = (int)HttpStatusCode.Unauthorized;
              response.Message = Hegic.Shared.Resource.Common.UnauthorizedRequestError;
              actionContext.Result = new JsonResult("")
                    {
                        Value = new { Status = response }
                    };
             }
          }
      }
