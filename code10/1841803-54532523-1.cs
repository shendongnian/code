        public class MyRequiredIfNotAttribute : RequiredAttribute//ValidationAttribute
        {
            private Type _type;
            public MyRequiredIfNotAttribute(Type type) {
                _type = type;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var actionContext = validationContext.GetRequiredService<IActionContextAccessor>();
                var controllerActionDescriptor = actionContext.ActionContext.ActionDescriptor as ControllerActionDescriptor;
                var controllerTypeName = controllerActionDescriptor.ControllerTypeInfo.Name;
                if (_type.Name == controllerTypeName)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return base.IsValid(value, validationContext);
                }            
            }
        }
