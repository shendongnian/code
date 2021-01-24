    #if ASPNETMVC
    using ExceptionValidationAttributeParent = System.Web.Mvc.IExceptionFilter;
    #elif ASPNETWEBAPI
    using ExceptionValidationAttributeParent = System.Web.Http.Filters.ExceptionFilterAttribute;
    #elif ASPNETCORE
    using ExceptionValidationAttributeParent = Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute;
    #else
    // default case but maybe redundant 
    using ExceptionValidationAttributeParent = SomeFakeParentClass;
    #endif
    namespace TestNetStandard
    {
        public class ExceptionValidationAttribute : ExceptionValidationAttributeParent
        {
            ...
        }
    }
