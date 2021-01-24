    public class Employee : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (string.IsNullOrEmpty(FirstName) || FirstName.Length > 50) {
                results.Add(new ValidationResult("Invalid first Name"));
            }
            if (string.IsNullOrEmpty(LastName) || LastName.Length > 50)
            {
                results.Add(new ValidationResult("Invalid last Name"));
            }
            
            return results;
        }
    }
