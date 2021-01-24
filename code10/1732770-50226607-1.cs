    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        var response = actionContext.Request.CreateResponse(HttpStatusCode.Redirect);
        response.Headers.Location = new Uri("https://www.example.com");
        actionContext.Response = response;
     }
