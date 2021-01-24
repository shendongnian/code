    public static class SchematicValidatorExtensions
    {
        public static bool TryValidate<TState, TInput>(
            this Schematic<TState, TInput> schematic, 
            out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(schematic, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                schematic, context, results,
                validateAllProperties: true
            );
        }
    }
