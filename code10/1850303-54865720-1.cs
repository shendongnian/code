     public class RequireWhenPutAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (System.Web.HttpContext.Current.Request.HttpMethod == "PUT")
                {
                    var obj = (ProjectDTO)validationContext.ObjectInstance;
                    if (obj.ProjectId == null)
                    {
                        return new ValidationResult("Project Id is Required");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
        public class ProjectDTO
        {
            [RequireWhenPut]
            public int? ProjectId { get; set; }
        }
