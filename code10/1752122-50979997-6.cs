    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using Microsoft.Extensions.Logging;
    
    namespace AspNetCorePlayground.Models
    {
        public class MyFirstModelBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                var valueProviderResult = bindingContext
                    .ValueProvider
                    .GetValue(bindingContext.ModelName);
    
                var cultureInfo = new CultureInfo("no"); // Norwegian
                decimal.TryParse(
                    valueProviderResult.FirstValue,
                    // add more NumberStyles as necessary
                    NumberStyles.AllowDecimalPoint, 
                    cultureInfo,
                    out var model);
    
                bindingContext
                    .ModelState
                    .SetModelValue(bindingContext.ModelName, valueProviderResult);
    
                bindingContext.Result = ModelBindingResult.Success(model);    
                return Task.CompletedTask;
            }
        }
    }
