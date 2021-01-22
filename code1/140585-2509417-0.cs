	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class EmailAddressAttribute : DataTypeAttribute {
		public EmailAddressAttribute() : base(DataType.EmailAddress) { ErrorMessage = "Please enter a valid email address"; }
		public override bool IsValid(object value) {
			if (value == null) return true;
			MailAddress address;
			try {
				address = new MailAddress(value.ToString());
			} catch (FormatException) { return false; }
			return address.Host.IndexOf('.') > 0;    //Email address domain names do not need a ., but in practice, they do.
		}
	}
