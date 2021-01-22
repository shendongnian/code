	public sealed class RequiredLocalized : RequiredAttribute {
			public override bool IsValid(object value) {
				if ( ! (ErrorMessageResourceType == null || String.IsNullOrWhiteSpace(ErrorMessageResourceName) )   ) {
					this.ErrorMessage = MVC_HtmlHelpers.Localize(this.ErrorMessageResourceType, this.ErrorMessageResourceName);
					this.ErrorMessageResourceType = null;
					this.ErrorMessageResourceName = null;
				}
				return base.IsValid(value);
			}
	}
