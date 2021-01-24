    namespace Microsoft.AspNetCore.Authorization
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class AllowAnonymousAttribute : Attribute, IAllowAnonymous
        {
            public AllowAnonymousAttribute();
        }
    }
