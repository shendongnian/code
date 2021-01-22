	/// <summary>
	/// Generates a dictionary allowing you to get the csharp enum value
	/// from the string value in the matching XmlEnumAttribute.
	/// You need this to be able to dynamically set entries from a xsd:enumeration
	/// when you've used xsd.exe to generate a .cs from the xsd.
	/// https://msdn.microsoft.com/en-us/library/x6c1kb0s(v=vs.110).aspx
	/// </summary>
	/// <typeparam name="T">The xml enum type you want the mapping for</typeparam>
	/// <returns>Mapping dictionary from attribute values (key) to the actual enum values</returns>
	/// <exception cref="System.ArgumentException">T must be an enum</exception>
	private static Dictionary<string, T> GetEnumMap<T>() where T : struct, IConvertible
	{
			if (!typeof(T).IsEnum)
			{
					throw new ArgumentException("T must be an enum");
			}
			var members = typeof(T).GetMembers();
			var map = new Dictionary<string, T>();
			foreach (var member in members)
			{
					var enumAttrib = member.GetCustomAttributes(typeof(XmlEnumAttribute), false).FirstOrDefault() as XmlEnumAttribute;
					if (enumAttrib == null)
					{
							continue;
					}
					var xmlEnumValue = enumAttrib.Name;
					var enumVal = ((FieldInfo)member).GetRawConstantValue();
					map.Add(xmlEnumValue, (T)enumVal);
			}
			return map;
	}
