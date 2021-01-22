    using System.Collections;
    using System.Web.Mvc;
    using System.Linq;
            
    namespace MyNamespace
    {
        public static class ModelStateExtensions
        {
            public static IEnumerable Errors(this ModelStateDictionary modelState)
            {
                if (!modelState.IsValid)
                {
                    return modelState.ToDictionary(kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()).Where(m => m.Value.Count() > 0);
                }
                return null;
            }
            
        }
        
    }
