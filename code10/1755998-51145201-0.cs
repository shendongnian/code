    public class IgnorePropertResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            //Todo: Check your custom attribute. You have MemberInfo here to navigate to your class and GetCustomAttributes<>
            property.ShouldSerialize = false; 
            return property;
        }
    }
