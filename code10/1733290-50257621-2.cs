        /// <summary>
        /// This is where the decoratee(E.g. the LogActionFilter) gets called. It is also where the implementation is contained
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        public class LogActionDecorator<TAttribute> : IActionFilter<TAttribute> where TAttribute : Attribute {
            private readonly IActionFilter<TAttribute> _decoratee;
    
            public LogActionDecorator(IActionFilter<TAttribute> decoratee, IAccountManagementManager iAccountManagementManager) {
                this._decoratee = decoratee;
            }
    
            public void OnActionExecuting(TAttribute attribute, ActionExecutingContext context) {
                this._decoratee.OnActionExecuting(attribute, context);
            }
        }
