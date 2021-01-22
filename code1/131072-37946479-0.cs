    //target class
    public class SomeClass{
        [CustomRequired(ErrorMessage = "{0} is required", ProperytName = "DisplayName")]
        public string Link { get; set; }
        public string DisplayName { get; set; }
    }
        //custom attribute
        public class CustomRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        public string ProperytName { get; set; }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var propertyValue = "Value";
            var parentMetaData = ModelMetadataProviders.Current
                 .GetMetadataForProperties(context.Controller.ViewData.Model, context.Controller.ViewData.Model.GetType());
            var property = parentMetaData.FirstOrDefault(p => p.PropertyName == ProperytName);
            if (property != null)
                propertyValue = property.Model.ToString();
            yield return new ModelClientValidationRule
            {
                ErrorMessage = string.Format(ErrorMessage, propertyValue),
                ValidationType = "required"
            };
        }
    }
