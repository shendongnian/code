     public static class ModelStateExtenstions
    {
        public static IEnumerable<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                              .Select(e => String.Join(" ", e.Value.Errors.Select(x => x.ErrorMessage)));
            }
            return Enumerable.Empty<string>();
        }
    }
