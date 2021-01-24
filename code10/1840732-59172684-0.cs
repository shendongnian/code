    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //treat query string parameters of type string, that have an empty string value,
            //(e.g. http://my/great/url?myparam=) as... empty strings!
            //and not as null, which is the default behaviour
            //see https://stackoverflow.com/q/54484640/505893
            GlobalConfiguration.Configuration.BindParameter(typeof(string), new EmptyStringModelBinder());
            
            //...
        }
    }
    /// <summary>
    /// Model binder that treats query string parameters that have an empty string value
    /// (e.g. http://my/great/url?myparam=) as... empty strings!
    /// And not as null, which is the default behaviour.
    /// </summary>
    public class EmptyStringModelBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            var vpr = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (vpr != null)
            {
                //parameter has been passed
                //preserve its value!
                //(if empty string, leave it as it is, instead of setting null)
                bindingContext.Model = vpr.AttemptedValue;
            }
            return true;
        }
    }
