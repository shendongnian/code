    public class PropertyTypeConverterContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.Converter == null)
            {
                // Can more than one TypeConverterAttribute be applied to a given member?  If so,
                // what should we do?
                var attr = property.AttributeProvider.GetAttributes(typeof(TypeConverterAttribute), false)
                    .OfType<TypeConverterAttribute>()
                    .SingleOrDefault();
                if (attr != null)
                {
                    var typeConverterType = GetTypeFromName(attr.ConverterTypeName, member.DeclaringType.Assembly);
                    if (typeConverterType != null)
                    {
                        var jsonConverter = new TypeConverterJsonConverter(typeConverterType);
                        if (jsonConverter.CanConvert(property.PropertyType))
                        {
                            property.Converter = jsonConverter;
                            // MemberConverter is obsolete or removed in later versions of Json.NET but
                            // MUST be set identically to Converter in earlier versions.
                            property.MemberConverter = jsonConverter;
                        }
                    }
                }
            }
    
            return property;
        }
        static Type GetTypeFromName(string typeName, Assembly declaringAssembly)
        {
            // Adapted from https://referencesource.microsoft.com/#System/compmod/system/componentmodel/PropertyDescriptor.cs,1c1ca94869d17fff
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            Type typeFromGetType = Type.GetType(typeName);
            Type typeFromComponent = null;
            if (declaringAssembly != null)
            {
                if ((typeFromGetType == null) ||
                    (declaringAssembly.FullName.Equals(typeFromGetType.Assembly.FullName)))
                {
                    int comma = typeName.IndexOf(',');
                    if (comma != -1)
                        typeName = typeName.Substring(0, comma);
                    typeFromComponent = declaringAssembly.GetType(typeName);
                }
            }
            return typeFromComponent ?? typeFromGetType;
        }
    }
