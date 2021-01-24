        // Method to get a Func that can parse your object
        private static Func<System.IO.Stream, T> GetParser<T>()
        {
            return (contextDto) => ControllerBase.ParseBody<T>(contextDto.Body);
        }
        // Use that in your dictionary
        private Dictionary<string, Func<System.IO.Stream, object>> transformers = new Dictionary<string, Func<System.IO.Stream, object>>
        {
            {  "/myPath", GetParser<CustomerPostDto>() },
            {  "/myPath-2", GetParser<CustomerPostDto>() }
        };
        // Now the LogAction method can just take the DTO that will be inferred from our parser
        private void LogAction<T>(T dto)
        {
            ...//Do some stuff here//...
        }
        // And call it as such
        if (transformers.ContainsKey(path))
                LogAction(transformers[path](context.Response.Body));
