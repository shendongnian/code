     public class RequireWhenPutAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (HttpContext.Current.Request.HttpMethod == "PUT")
                {
                    var obj = (ParentDto)validationContext.ObjectInstance;
                    if (obj.Id == null)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
        public class ParentDto
        {
            [RequireWhenPut(ErrorMessage = "Id is required")]
            public int? Id { get; set; }
        }
        public class UserDTO : ParentDto
        {
            // Other properties
        }
        public class ProjectTypeDTO : ParentDto
        {
            // Other properties
        }
        public class ProjectDTO : ParentDto
        {
             // Other properties
        }
