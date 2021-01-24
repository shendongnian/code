    public static class ModelStateExtensions
    {
        /// <summary>
        /// Reads all the error messages in a <see cref="ModelStateDictionary"/> as 
        /// a collection and returns a JSON <see cref="string"/> of the list.
        /// </summary>
        /// <param name="modelstate">Current modelstate assuming that you've checked
        /// and confirmed that is Invalid using <see 
        /// cref="ModelStateDictionary.IsValid"/>
        /// </param>
        /// <returns>
        /// Collection of validation errors for the model as a JSON string.
        /// </returns>
        public static string ToJson(this ModelStateDictionary modelstate)
        {
            List<string> errors = modelstate.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)
                                            .ToList();
            return JsonConvert.SerializeObject(errors);
        }
    }
