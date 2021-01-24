    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    
    namespace Media.Onsite.Api.Middleware.ModelBindings
    {
        public class Startup2
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc(options =>
                {
                    // add the custom binder at the top of the collection
                    options.ModelBinderProviders.Insert(0, new MyCustomModelBinderProvider());
                });
            }
        }
    
        public class MyCustomModelBinderProvider : IModelBinderProvider
        {
            public IModelBinder GetBinder(ModelBinderProviderContext context)
            {
                if (context.Metadata.ModelType == typeof(MyType))
                {
                    return new BinderTypeModelBinder(typeof(MyCustomModelBinder));
                }
    
                return null;
            }
        }
    
        public class MyCustomModelBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                {
                    throw new ArgumentNullException(nameof(bindingContext));
                }
    
                if (bindingContext.ModelType != typeof(MyType))
                {
                    return Task.CompletedTask;
                }
    
                string modelName = string.IsNullOrEmpty(bindingContext.BinderModelName)
                    ? bindingContext.ModelName
                    : bindingContext.BinderModelName;
    
                ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
                if (valueProviderResult == ValueProviderResult.None)
                {
                    return Task.CompletedTask;
                }
    
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
    
                string valueToBind = valueProviderResult.FirstValue;
    
                if (valueToBind == null /* or not valid somehow*/)
                {
                    return Task.CompletedTask;
                }
    
                MyType value = ParseMyTypeFromJsonString(valueToBind);
    
                bindingContext.Result = ModelBindingResult.Success(value);
    
                return Task.CompletedTask;
            }
    
            private MyType ParseMyTypeFromJsonString(string valueToParse)
            {
                return new MyType
                {
                    // Parse JSON from 'valueToParse' and apply your magic here
                };
            }
        }
    
        public class MyType
        {
            // Your props here
        }
    
        public class MyRequestType
        {
            [JsonConverter(typeof(UniversalDateTimeConverter))]
            public MyType PropName { get; set; }
    
            public string OtherProp { get; set; }
        }
    }
