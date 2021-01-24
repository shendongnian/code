    public sealed class AgeCheck : ValidationAttribute
        {
            public DateTime Birthday;
            public DateTime Eighteen = DateTime.Now.Date.AddDays(-6573);
    
            protected override ValidationResult IsValid(object Birthday, ValidationContext validationContext)
            {
                if (Eighteen <= Convert.ToDateTime(Birthday))
                {
                    return new ValidationResult("You must be eighteen to use this website");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
