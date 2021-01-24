        /// <summary>
        /// Analyzes an incoming HttpContext to determine if the auth token should be taken from the query string
        /// </summary>
        /// <param name="httpContext">The HttpContext containing the request with user identity claims to analzye</param>
        /// <returns>A task to execute the next middleware component in the HTTP request processing pipeline</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var accessToken = httpContext.Request.Query["access_token"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpContext.Request.Headers["Authorization"] = $"Bearer {accessToken}";
            }
            await next.Invoke(httpContext);
        }
