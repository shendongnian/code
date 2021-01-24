    public class CustomContractResolver : DefaultContractResolver
    {
        public static CustomContractResolver Instance { get; } = new CustomContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (member.Name == "LazyLoader")
            {
                property.Ignored = true;
            }
            return property;
        }
    
    }
