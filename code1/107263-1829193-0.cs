       // http://www.crydust.be/blog/2009/07/30/custom-model-binder-to-avoid-decimal-separator-problems/
    public class MoneyParsableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
          ModelBindingContext bindingContext)
        {
            object result = null;
            // Added support for decimals and nullable types - c.
            if (
                bindingContext.ModelType == typeof(double)
                || bindingContext.ModelType == typeof(decimal)
                || bindingContext.ModelType == typeof(double?)
                || bindingContext.ModelType == typeof(decimal?)
                )
            {
                string modelName = bindingContext.ModelName;
                string attemptedValue = bindingContext.ValueProvider[modelName].AttemptedValue;
                // Depending on cultureinfo the NumberDecimalSeparator can be "," or "."
                // Both "." and "," should be accepted, but aren't.
                string wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                string alternateSeperator = (wantedSeperator == "," ? "." : ",");
                if (attemptedValue.IndexOf(wantedSeperator) == -1
                  && attemptedValue.IndexOf(alternateSeperator) != -1)
                {
                    attemptedValue = attemptedValue.Replace(alternateSeperator, wantedSeperator);
                }
                // If SetModelValue is not called it may result in a null-ref exception if the model is resused - c. 
                bindingContext.ModelState.SetModelValue(modelName, bindingContext.ValueProvider[modelName]);
                try
                {
                    // Added support for decimals and nullable types - c.
                    if (bindingContext.ModelType == typeof(double) || bindingContext.ModelType == typeof(double?))
                    {
                        result = double.Parse(attemptedValue, NumberStyles.Any);
                    }
                    else
                    {
                        result = decimal.Parse(attemptedValue, NumberStyles.Any);
                    }
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(modelName, e);
                }
            }
            else
            {
                result = base.BindModel(controllerContext, bindingContext);
            }
            return result;
        }
    }
