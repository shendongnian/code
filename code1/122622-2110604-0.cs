    public class JsonFilter<T> : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<T>(inputContent);//Error here
        }
    }
