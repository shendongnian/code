    public class RussianActionFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // you may want to play with RouteData in order to make this check more elegant   
            if (context.HttpContext.Request.Path.Value.Contains("About"))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
