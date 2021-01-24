    public abstract class ActionFilterBehaviorBase<TAttribute> : IActionFilter where TAttribute : Attribute
    {
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (ControllerHasAttribute(actionContext) || ActionHasAttribute(actionContext))
            {
                return ExecuteFilterBehavior(actionContext, cancellationToken, continuation);
            }
            return continuation();
        }
        protected abstract Task<HttpResponseMessage>  ExecuteFilterBehavior(HttpActionContext actionContext, CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation);
        public virtual bool AllowMultiple { get; } = false;
        private bool ControllerHasAttribute(HttpActionContext actionContext)
        {
            return actionContext
                    .ControllerContext.Controller.GetType()
                    .GetCustomAttributes(false)
                    .Any(attribute => attribute.GetType().IsAssignableFrom(typeof(TAttribute)));
        }
        private bool ActionHasAttribute(HttpActionContext actionContext)
        {
            return actionContext
                .ActionDescriptor
                .GetCustomAttributes<TAttribute>()
                .Any();
        }
    }
