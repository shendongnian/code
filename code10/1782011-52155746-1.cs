    static class AddResultExtensions
    {
        public static IAddResult Transform(this IAddResult addResult)
        {
            // TODO: Transform add result.
            throw new NotImplementedException();
        }
    
        public static void IfValid(this IAddResult addResult, Action thenInvokeThis, 
            Action elseInvokeThis)
        {
            // TODO: Validate.
            bool isValid = true ? throw new NotImplementedException() 
                : false;
    
            if (isValid)
            {
                thenInvokeThis();
            }
            else
            {
                elseInvokeThis();
            }
        }
    }
