    public class JsonFilter<TJsonData> : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ...
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<TJsonData>(inputContent);
            //...
        }
    }
