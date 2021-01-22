    [HasSelfValidation]
    public class Person
    {
        public string Name { get; set; }
        public bool IsSenior { get; set; }
        public Senior Senior { get; set; }
    
        [SelfValidation]
        public void ValidateRange(ValidationResults results)
        {
            if (this.IsSenior && this.Senior != null && 
                string.IsNullOrEmpty(this.Senior.Description))
            {
                results.AddResult(new ValidationResult(
                    "A senior description is required", 
                    this, "", "", null));
            }
        }
    }
