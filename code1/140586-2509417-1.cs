	public class EmailAddressValidator : DataAnnotationsModelValidator<EmailAddressAttribute> {
		public EmailAddressValidator(ModelMetadata metadata, ControllerContext context, EmailAddressAttribute attribute) : base(metadata, context, attribute) { }
		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
			yield return new ModelClientValidationRegexRule(Attribute.ErrorMessage, 
                         @".+@.+\..+");    //Feel free to use a bigger regex
		}
	}
