    public partial class NorthwindDataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            var invalidResults = (
                from entity in this.GetChangedEntities()
                let type = entity.GetType()
                let validator = ValidationFactory.CreateValidator(type)
                let results = validator.Validate(entity)
                where !results.IsValid
                from result in results
                select result).ToArray();            
    
            if (invalidResults.Length > 0)
            {
                // You should define this exception type
                throw new ValidationException(invalidResults);
            }
    
            base.SubmitChanges(failureMode);
        }
    
        private IEnumerable<object> GetChangedEntities()
        {
            ChangeSet changes = this.GetChangeSet();
            return changes.Inserts.Concat(changes.Updates);
        }
    }
