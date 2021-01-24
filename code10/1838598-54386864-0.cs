    public static class ModelStateHelper
    {
        public static List<string> Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
              return ModelState.Values.SelectMany(v => v.Errors).Select(x=>x.ErrorMessage).ToList();
            }
            return new List<string>();
        }
    }
