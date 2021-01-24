	using System;
	using System.Globalization;
	using System.Web.Mvc;  
	
    public class CustomDecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// Gets the decimal value from data received
        /// </summary>
        /// <param name="controllerContext">Controller context</param>
        /// <param name="bindingContext">Binding context</param>
        /// <returns>Parsed value</returns>
        public object BindModel(ControllerContext controllerContext, 
								System.Web.Mvc.ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            var modelState = new System.Web.Mvc.ModelState { 
											Value = result 
										};
            object actualValue = null;
            var culture = CultureInfo.CurrentCulture;
            if (result.AttemptedValue != string.Empty)
            {
                try
                {
                    // Try with your current culture
                    actualValue = Convert.ToDecimal(result.AttemptedValue, culture);
                }
                catch (FormatException)
                {
                    try
                    {
                        // Try with invariant culture if current culture failed
                        actualValue = Convert.ToDecimal(result.AttemptedValue, 
													CultureInfo.InvariantCulture);
                    }
                    catch (FormatException ex)
                    {
                        modelState.Errors.Add(ex);
                    }
                }
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
