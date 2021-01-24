	public class NoNullWhiteSpaceResolver : DefaultContractResolver {
		public static readonly NoNullWhiteSpaceResolver Instance = new NoNullWhiteSpaceResolver();
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
			JsonProperty property = base.CreateProperty(member, memberSerialization);
			if (property.PropertyType == typeof(string)) {
				property.ShouldSerialize =
					instance => {
						try {
							var rawValue = property.ValueProvider.GetValue(instance);
							if (rawValue == null) {
								return false;
							}
							string stringValue = property.ValueProvider.GetValue(instance).ToString();
							return !string.IsNullOrWhiteSpace(stringValue);
						}
						catch {
							return true;
						}
					};
			}
			return property;
		}
	}
