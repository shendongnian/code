    /// <summary>
    /// My ActionFilter which takes an Attribute
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type(E.g ActionFilterAttribute)</typeparam>
    public interface IActionFilter<TAttribute> where TAttribute : Attribute {
        //My OnActionExecuting method which will be called when an Action is being executed. It can be extended to include other methods such as OnActionExecuted if required
        void OnActionExecuting(TAttribute attribute, ActionExecutingContext context);
    }
