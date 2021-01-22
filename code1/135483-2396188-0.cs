    public partial class NorthwindDataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            ValidationResult[] = this.Validate();
            if (invalidResults.Length > 0)
            {
                // You should define this exception type
                throw new ValidationException(invalidResults);
            }
            base.SubmitChanges(failureMode);
        }
        private ValidationResult[] Validate()
        {
            // here we use the Validation Application Block.
            return invalidResults = (
                from entity in this.GetChangedEntities()
                let type = entity.GetType()
                let validator = ValidationFactory.CreateValidator(type)
                let results = validator.Validate(entity)
                where !results.IsValid
                from result in results
                select result).ToArray();            
        }
        private IEnumerable<object> GetChangedEntities()
        {
            ChangeSet changes = this.GetChangeSet();
            return changes.Inserts.Concat(changes.Updates);
        }
    }
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> results)
            : base("There are validation errors.")
        {
            this.Results = new ReadOnlyCollection<ValidationResult>(
                results.ToArray());
        }
        public ReadOnlyCollection<ValidationResult> Results
        {
            get; private set; 
        }
    }
