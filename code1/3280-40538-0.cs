    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Determines if the current view equals the specified action
        /// </summary>
        /// <typeparam name="TController">The type of the controller.</typeparam>
        /// <param name="helper">Url Helper</param>
        /// <param name="action">The action to check.</param>
        /// <returns>
        /// 	<c>true</c> if the specified action is the current view; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAction<TController>(this UrlHelper helper, LambdaExpression action) where TController : Controller
        {
            MethodCallExpression call = action.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException("Expression must be a method call", "action");
            }
            return (call.Method.Name.Equals(helper.ViewContext.ViewName, StringComparison.OrdinalIgnoreCase) &&
                    typeof(TController) == helper.ViewContext.Controller.GetType());
        }
        /// <summary>
        /// Determines if the current view equals the specified action
        /// </summary>
        /// <param name="helper">Url Helper</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns>
        /// 	<c>true</c> if the specified action is the current view; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAction(this UrlHelper helper, string actionName)
        {
            if (String.IsNullOrEmpty(actionName))
            {
                throw new ArgumentException("Please specify the name of the action", "actionName");
            }
            string controllerName = helper.ViewContext.RouteData.GetRequiredString("controller");
            return IsAction(helper, actionName, controllerName);
        }
        /// <summary>
        /// Determines if the current view equals the specified action
        /// </summary>
        /// <param name="helper">Url Helper</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns>
        /// 	<c>true</c> if the specified action is the current view; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAction(this UrlHelper helper, string actionName, string controllerName)
        {
            if (String.IsNullOrEmpty(actionName))
            {
                throw new ArgumentException("Please specify the name of the action", "actionName");
            }
            if (String.IsNullOrEmpty(controllerName))
            {
                throw new ArgumentException("Please specify the name of the controller", "controllerName");
            }
            if (!controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                controllerName = controllerName + "Controller";
            }
            bool isOnView = helper.ViewContext.ViewName.SafeEquals(actionName, StringComparison.OrdinalIgnoreCase);
            return isOnView && helper.ViewContext.Controller.GetType().Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase);
        }
    }
