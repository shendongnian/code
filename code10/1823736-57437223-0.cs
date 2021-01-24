    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        var contentType = request.ContentType;
        if (contentType.StartsWith("application/x-www-form-urlencoded")) // in case it ends with ";charset=UTF-8"
        {
            var content = string.Empty;
            foreach (var key in request.Form.Keys)
            {
                if (request.Form.TryGetValue(key, out var value))
                {
                    content += $"{key}={value}&";
                }
            }
            content = content.TrimEnd('&');
            return await InputFormatterResult.SuccessAsync(content);
        }
        return await InputFormatterResult.FailureAsync();
    }
