    using System.ComponentModel.DataAnnotations;
    
    namespace StatisticsWeb.Models
    {
        public class PatientFormBirthdayValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var patient = (Patient)validationContext.ObjectInstance;
                if (patient.BirthDate == null)
                {
                    return new ValidationResult("Date of Birth field is required");
                }
                else if ((patient.BirthDate >= DateTime.Now) || (patient.BirthDate < DateTime.MinValue))
                {
                    return new ValidationResult("Date of Birth is invalid");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }
