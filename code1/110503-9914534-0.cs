    public class LocalizedRequiredAttribute : RequiredAttribute, IClientValidatable 
    {
        public LocalizedRequiredAttribute(string resourceName)
        {
            this.ErrorMessage = Resources.GetResource(resourceName);
        }
        
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessage,
                ValidationType= "required"
            };
        }
    }
