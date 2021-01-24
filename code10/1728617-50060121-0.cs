    public class StringType
	{
		public StringType(IDictionary<MemberInfo, string> allPropertiesAndFields)
		{
			this.PropertiesAndFields = allPropertiesAndFields;
			this.PropertyFieldNamesAndValues = allPropertiesAndFields.ToDictionary(m => m.Key.Name, m => m.Value);
		}
		private IDictionary<MemberInfo, string> PropertiesAndFields { get; set; }
		private IDictionary<string, string> PropertyFieldNamesAndValues { get; set; }
		public string GetValue(string propertyOrFieldName)
		{
			bool isKnown = PropertyFieldNamesAndValues.TryGetValue(propertyOrFieldName, out string value);
			if (isKnown)
				return value;
			return null;
		}
		// if you want to know all informations about the property or field like type
		public MemberInfo GetMemberInfo(string propertyOrFieldName)
		{
			MemberInfo memberInfo = PropertiesAndFields.Keys.FirstOrDefault(mi => mi.Name == propertyOrFieldName);
			return memberInfo;
		}
	}
