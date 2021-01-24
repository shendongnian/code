    public class CaseInfoRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var caseInfo = (CaseInformation) validationContext.ObjectInstance;
            if (string.IsNullOrEmpty(caseInfo.CaseNumber) &&
    			string.IsNullOrEmpty(caseInfo.RitNumber) &&
    			string.IsNullOrEmpty(caseInfo.ApilNumber))
            {
                return new ValidationResult("Either CaseNumber or RitNumber or ApilNumber is required.");
            }
            return ValidationResult.Success;        
        }
    }
