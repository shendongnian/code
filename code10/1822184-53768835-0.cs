    public class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.DeclaringType == typeof(Person) && prop.UnderlyingName == "LastName")
            {
                prop.Converter = new AllCapsConverter();
            }
            return prop;
        }
    }
