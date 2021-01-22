    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false, Inherited = false )]
    public class HttpPostOrDeleteAttribute : ActionMethodSelectorAttribute
    {
        private static readonly AcceptVerbsAttribute _innerPostAttribute = new AcceptVerbsAttribute( HttpVerbs.Post );
        private static readonly AcceptVerbsAttribute _innerDeleteAttribute = new AcceptVerbsAttribute( HttpVerbs.Delete );
    
        public override bool IsValidForRequest( ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo )
        {
            return _innerDeleteAttribute.IsValidForRequest( controllerContext, methodInfo )
                   || _innerPostAttribute.IsValidForRequest( controllerContext, methodInfo );
        }
    }
