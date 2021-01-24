	internal class CustomContractResolver : DefaultContractResolver
	{
		public CustomContractResolver(string fieldName)
		{
			FieldName = fieldName;
		}
		public string FieldName { get; set; }
		protected override string ResolvePropertyName(string propertyName)
		{
			return propertyName == "fieldName" ? FieldName : base.ResolvePropertyName(propertyName);
		}
	}
