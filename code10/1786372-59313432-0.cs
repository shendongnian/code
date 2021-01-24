using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text;
namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfTrueAttribute : ValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; set; }
               
        public RequiredIfTrueAttribute(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = "The {0} field is required."; //used if error message is not set on attribute itself
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();
            bool.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out bool propertyValue);
            if (propertyValue && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-requirediftrue", errorMessage);
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}
**Client-Side Javascript**
    //Custom validation script for the RequiredIfTrue validator
    /*
     * Note that, jQuery validation registers its rules before the DOM is loaded. 
     * If you try to register your adapter after the DOM is loaded, your rules will
     * not be processed. So wrap it in a self-executing function.
     * */
    (function ($) {
    
        var $jQval = $.validator;
    
       $jQval.addMethod("requirediftrue",
           function (value, element, parameters) {
                return value !== "" && value != null;
            }
        );
    
        var adapters = $jQval.unobtrusive.adapters;
        adapters.addBool('requirediftrue');
    
    })(jQuery);
**Usage**
        public bool IsSpecialField { get; set; }
        [RequiredIfTrue(nameof(IsSpecialField), ErrorMessage="This is my custom error message")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [RequiredIfTrue(nameof(IsSpecialField))]
        public string City { get; set; }
