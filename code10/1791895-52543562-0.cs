    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey(CorsConstants.Origin))
        {
            var corsPolicy = _policy ?? await _corsPolicyProvider?.GetPolicyAsync(context, _corsPolicyName);
            if (corsPolicy != null)
            {
                var corsResult = _corsService.EvaluatePolicy(context, corsPolicy);
                _corsService.ApplyResult(corsResult, context.Response);
        ...
