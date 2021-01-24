    public class CaseInformation : IValidatableObject
    {
        ...
        public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
        {
            if (string.IsNullOrWhiteSpace(CaseNumber) &&
                string.IsNullOrWhiteSpace(RitNumber) &&
                string.IsNullOrWhiteSpace(ApilNumber))
            {
                yield return new ValidationResult("Your error message here.");
            }
        }
    }
