     public class RequiredWhenPutAttribute : ValidationAttribute
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
            [RequiredWhenPut(ErrorMessage = "Id is required")]
            public int? Id { get; set; }
        }
        public class UserDTO : ParentDto
        {
            // properties
        }
        public class ProjectTypeDTO : ParentDto
        {
            // properties
        }
        public class ProjectDTO : ParentDto
        {
             // properties
        }
