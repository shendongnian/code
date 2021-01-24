        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Request.Path.Value.Contains("odata"))
            {
                var methodInfo = context.ActionDescriptor.GetMethodInfo();
>
                var wrapResultAttribute =
                    GetSingleAttributeOfMemberOrDeclaringTypeOrDefault(
                        methodInfo,
                        _configuration.DefaultWrapResultAttribute
                    );
