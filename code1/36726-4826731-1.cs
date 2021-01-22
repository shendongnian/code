    static class EntityValidator
    {
        public static void Validate(IEnumerable<object> entities)
        {
            ValidationResults[] invalidResults = (
                from entity in entities
                let type = entity.GetType()
                let validator = ValidationFactory.CreateValidator(type)
                let results = validator.Validate(entity)
                where !results.IsValid
                select results).ToArray();
         
            // Throw an exception when there are invalid results.
            if (invalidResults.Length > 0)
            {
                throw new ValidationException(invalidResults);
            }
        }
    }
