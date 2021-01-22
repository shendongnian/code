    public sealed partial class RegistrationData 
    { 
        [Key] 
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ErrorResources))] 
        [Display(Order = 0, Name = "UserNameLabel", ResourceType = typeof(RegistrationDataResources))] 
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessageResourceName = "ValidationErrorInvalidUserName", ErrorMessageResourceType = typeof(ErrorResources))] 
        [StringLength(255, MinimumLength = 4, ErrorMessageResourceName = "ValidationErrorBadUserNameLength", ErrorMessageResourceType = typeof(ErrorResources))] 
        public string UserName { get; set; } 
