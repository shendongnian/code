    public class JsonFilter : ActionFilterAttribute
    {
        public Type JsonDataType { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ...
            JavaScriptSerializer jss = new JavaScriptSerializer();
            MethodInfo method = jss.GetType()
                                   .GetMethod("Deserialize");
                                   .MakeGenericMethod(new Type[] { JsonDataType });
            method.Invoke(jss, new object[] { inputContent });
            //...
        }
    }
