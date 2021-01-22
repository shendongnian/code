     using System;
     using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;
     using System.Globalization;
     using System.Web.Mvc;
     using System.Web.Security;
     namespace GDNET.Web.Mvc.Validation
     {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
    {
        private const string defaultErrorMessage = "'{0}' must be at least {1} characters long.";
        private readonly int minRequiredPasswordLength = Membership.Provider.MinRequiredPasswordLength;
        public ValidatePasswordLengthAttribute()
            : base(defaultErrorMessage)
        {
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, minRequiredPasswordLength);
        }
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= minRequiredPasswordLength);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]
            {
                new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), minRequiredPasswordLength, int.MaxValue)
            };
        }
    }
      }
