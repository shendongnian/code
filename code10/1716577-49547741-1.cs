    public class search : IValidatableObject
    {
        public string Sample1 { get; set; }
        public string Sample2 { get; set; }
        public string Sample3 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
            var results = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Sample1) && string.IsNullOrEmpty(Sample2) && string.IsNullOrEmpty(Sample3))
            {
                results.Add(new ValidationResult("One of them is required."));
            }
            return results;
        }
    }
