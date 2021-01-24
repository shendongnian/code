    public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
    {
        string errorMessage = "User has no enough permissions to perform requested operation.";
        var httpContent = new StringContent("{ \"some\": \"json\"}", Encoding.UTF8, "application/json");
        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
        {
            ReasonPhrase = errorMessage,
            Content = httpContent
        };
        return Task.FromResult<object>(null);
    }
