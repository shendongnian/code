    namespace Foo
    {
        using System.ComponentModel.DataAnnotations;
        using System.Linq;
    
        /// <summary>
        /// Attribute class used to validate child properties.
        /// </summary>
        /// <remarks>
        /// See: http://stackoverflow.com/questions/2493800/how-can-i-tell-the-data-annotations-validator-to-also-validate-complex-child-pro
        /// Apparently the Data Annotations validator does not validate complex child properties.
        /// To do so, slap this attribute on a your property (probably a nested view model) 
        /// whose type has validation attributes on its properties.
        /// This will validate until a nested <see cref="System.ComponentModel.DataAnnotations.ValidationAttribute" /> 
        /// fails. The failed validation result will be returned. In other words, it will fail one at a time. 
        /// </remarks>
        public class HasNestedValidationAttribute : ValidationAttribute
        {
            /// <summary>
            /// Validates the specified value with respect to the current validation attribute.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="validationContext">The context information about the validation operation.</param>
            /// <returns>
            /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
            /// </returns>
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var isValid = true;
                var result = ValidationResult.Success;
    
                var nestedValidationProperties = value.GetType().GetProperties()
                    .Where(p => IsDefined(p, typeof(ValidationAttribute)))
                    .OrderBy(p => p.Name);//Not the best order, but at least known and repeatable.
    
                foreach (var property in nestedValidationProperties)
                {
                    var validators = GetCustomAttributes(property, typeof(ValidationAttribute)) as ValidationAttribute[];
    
                    if (validators == null || validators.Length == 0) continue;
    
                    foreach (var validator in validators)
                    {
                        var propertyValue = property.GetValue(value, null);
    
                        result = validator.GetValidationResult(propertyValue, new ValidationContext(value, null, null));
                        if (result == ValidationResult.Success) continue;
    
                        isValid = false;
                        break;
                    }
    
                    if (!isValid)
                    {
                        break;
                    }
                }
                return result;
            }
        }
    }
