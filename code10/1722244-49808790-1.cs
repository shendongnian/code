    public class CreateTaskInput : ICustomValidate
    {
        public int? AssignedPersonId { get; set; }
    
        public bool SendEmailToAssignedPerson { get; set; }
    
        [Required]
        public string Description { get; set; }
    
        public void AddValidationErrors(CustomValidatationContext context)
        {
            if (SendEmailToAssignedPerson && (!AssignedPersonId.HasValue || AssignedPersonId.Value <= 0))
            {
                context.Results.Add(new ValidationResult("AssignedPersonId must be set if SendEmailToAssignedPerson is true!"));
            }
        }
    }
