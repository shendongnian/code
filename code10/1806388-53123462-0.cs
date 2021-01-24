    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    
	namespace CustomBinders
	{
		public class DecimalBinderProvider : IModelBinderProvider
		{
			public IModelBinder GetBinder(ModelBinderProviderContext context)
			{
				if (context == null)
				{
					throw new ArgumentNullException(nameof(context));
				}
				if (context.Metadata.ModelType == typeof(decimal))
				{
					return new BinderTypeModelBinder(typeof(DecimalBinder));
				}
				if (context.Metadata.ModelType == typeof(decimal?))
				{
					return new BinderTypeModelBinder(typeof(DecimalBinder));
				}
				return null;
			}
		}
		public class DecimalBinder : IModelBinder
		{
			public Task BindModelAsync(ModelBindingContext bindingContext)
			{
				if (bindingContext == null)
				{
					throw new ArgumentNullException(nameof(bindingContext));
				}
				var valueResult = bindingContext.ValueProvider
					 .GetValue(bindingContext.ModelName);
				if (valueResult == ValueProviderResult.None)
				{
					return Task.CompletedTask;
				}
				object actualValue = null;
				var culture = CultureInfo.CurrentCulture;
				
				if (valueResult.FirstValue != string.Empty)
				{
					try
					{
						// Try with your local culture
						actualValue = Convert.ToDecimal(valueResult.FirstValue, culture);
					}
					catch (FormatException)
					{
						try
						{
							// Try with your invariant culture
							actualValue = Convert.ToDecimal(valueResult.FirstValue, CultureInfo.InvariantCulture);
						}
						catch (FormatException)
						{
							bindingContext.ModelState.TryAddModelError(
										bindingContext.ModelName,
										"You should provide a valid decimal value");
							return Task.CompletedTask;
						}
					}
				}
				bindingContext.Result = ModelBindingResult.Success(actualValue);
				return Task.CompletedTask;
			}
		}
	}
