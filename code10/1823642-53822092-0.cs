    public class Dad : IValidatableObject
    {
        public long Id { get; set; }
        [Required]
        public Kid Kid { get; set; }
    
        [NotMapped, JsonIgnore]
        pricate List<ValidationResult> ValidationResults = new List<ValidationResult>();
        public void UpdateProperties(JObject props)
        {
            if (props["Kid"]["Id"] == null)
                ValidationResults.Add(new ValidationResult("The correct format to set the Kid of Dad is {\"Kid\":{\"Id\":100}}", new string[] { "Kid" }));
        }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Kid.Height <= 170)
                yield return new ValidationResult("Kids need to be taller than 170.")
    
            if (ValidationResults.Count > 0)
                    foreach (ValidationResult r in ValidationResults)
                        yield return r;
        }
    }
