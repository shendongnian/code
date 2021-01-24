        invocation.ReturnValue = GetAsync((dynamic)invocation.ReturnValue, serializer, headers, req);
        internal static Task<T> GetAsync<T>(Task<T> originalTask, ISerializer serializer, Headers headers, InvokeHttpRequest req)
        {
            return Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    var httpResponse = await PerformGetAsync(headers, req, client);
                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                    return ProcessResult<T>(serializer, jsonResponse);
                }
            });
        }
