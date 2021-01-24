    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                objectResult.Value = new ApiResult { Data = objectResult.Value };
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
