    /// <summary>
    /// The dispatcher(which gets added to the GlobalFilters) requires the simple injector container which contains all instances of injected classes.
    /// Inherit from the MVC library IActionFilter in order to gain access to the OnActionExecuting method
    /// </summary>
    public class ActionFilterDispatcher : IActionFilter {
        private readonly Func<Type, IEnumerable> _container;
        public ActionFilterDispatcher(Func<Type, IEnumerable> container) {
            this._container = container;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext) { }
        public void OnActionExecuting(ActionExecutingContext context) {
            var descriptor = context.ActionDescriptor;
            //Get all attributes on a controller/action and cast them to the generic Attribute class
            var attributes = descriptor.ControllerDescriptor.GetCustomAttributes(true)
                .Concat(descriptor.GetCustomAttributes(true))
                .Cast<Attribute>();
            //Foreach attribute call the OnActionExecuting method for the IActionFilter of the attribute(E.g LogActionDecoraor)
            foreach (var attribute in attributes) {
                Type filterType = typeof(IActionFilter<>).MakeGenericType(attribute.GetType());
                IEnumerable filters = this._container.Invoke(filterType);
                foreach (dynamic actionFilter in filters) {
                    actionFilter.OnActionExecuting((dynamic)attribute, context);
                }
            }
        }
    }
