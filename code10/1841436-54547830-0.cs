            var user = httpContext.User;
            var userIsAnonymous =
                user?.Identity == null ||
                !user.Identities.Any(i => i.IsAuthenticated);
            if (userIsAnonymous)
            {
                httpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
            return _next(httpContext);
