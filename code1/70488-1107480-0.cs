    public static Parser<T> GetParser<T>(T defaultResult)
        where T : struct
    {
        // create parsing method
        Parser<T> parser = (string value, out T result) =>
        {
            // look for TryParse(string value,out T result)
            var parseMethod = 
                typeof(T).GetMethods()
                         .Where(p => p.Name == "TryParse")
                         .Where(p => p.GetParameters().Length == 2)
                         .Single();
            // make parameters, leaving second element uninitialized means out/ref parameter
            object[] parameters = new object[2];
            parameters[0] = value;
            // run parse method
            bool success = (bool)parseMethod.Invoke(null, parameters);
            // if successful, set result to output
            if (!success)
            {
                result = (T)parameters[1];
            }
            else
            {
                result = defaultResult;
            }
            return success;
        };
        return parser;
    }
