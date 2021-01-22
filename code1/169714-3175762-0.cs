    public class DoubleModelBinder : IModelBinder
    {
        /// <summary>
        /// Binds the value to the model.
        /// </summary>
        /// <param name="controllerContext">The current controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The new model.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var culture = GetUserCulture(controllerContext);
            string value = bindingContext.ValueProvider
                               .GetValue(bindingContext.ModelName)
                               .ConvertTo(typeof(string)) as string;
            double result = 0;
            double.TryParse(value, NumberStyles.Any, culture, out result);
            return result;
        }
        /// <summary>
        /// Gets the culture used for formatting, based on the user's input language.
        /// </summary>
        /// <param name="context">The controller context.</param>
        /// <returns>An instance of <see cref="CultureInfo" />.</returns>
        public CultureInfo GetUserCulture(ControllerContext context)
        {
            var request = context.HttpContext.Request;
            if (request.UserLanguages == null || request.UserLanguages.Length == 0)
                return CultureInfo.CurrentUICulture;
            return new CultureInfo(request.UserLanguages[0]);
        }
    }
