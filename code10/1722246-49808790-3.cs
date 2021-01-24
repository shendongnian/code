    public class CreateTaskInput : ICustomValidate
    {
        public int? AssignedPersonId { get; set; }
    
        public bool SendEmailToAssignedPerson { get; set; }
    
        public void AddValidationErrors(CustomValidatationContext context)
        {
            if (SendEmailToAssignedPerson && (!AssignedPersonId.HasValue || AssignedPersonId.Value <= 0))
            {
                var errorMessage = "AssignedPersonId must be set if SendEmailToAssignedPerson is true!";
                context.Results.Add(new ValidationResult(errorMessage));
            }
        }
    }
