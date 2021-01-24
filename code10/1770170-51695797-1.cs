    public static class ResultFactory
    {
        public static ReturnObject<T> GetGoodResult<T>(T result)
        {
            return new ReturnObject { Success = true, Result = result };
        }
    
    
        public static ReturnObject<T> GetGoodResult<T>(T result, IEnumerable<string> errors)
        {
            return new ReturnObject { Success = false, Errors = errors, Result = result };
        }
    }
