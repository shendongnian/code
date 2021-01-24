    public class NoValidationAttribute : ValidationAttribute
    {
        public static void RemoveValidation(ActionExecutingContext context)
        {
            // Get the properties that contain the [NoValidationAttribute]
            var properties = context.ActionArguments.First().Value.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(a =>
                    a.GetCustomAttributes(true).OfType<NoValidationAttribute>().Any());
            // For each of the properties remove the modelstate errors.
            foreach (var property in properties)
            {
                foreach (var key in context.ModelState.Keys.Where(k =>
                    k.StartsWith($"{property.Name}["))) // Item index is part of key [
                {
                    context.ModelState.Remove(key);
                }
            }
        }
    }
