    class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            JsonObjectAttribute attr = prop.DeclaringType.GetCustomAttribute<JsonObjectAttribute>();
            if (attr != null && attr.MemberSerialization == MemberSerialization.Fields && 
                member.GetCustomAttribute<CompilerGeneratedAttribute>() != null)
            {
                prop.Ignored = true;
            }
            return prop;
        }
    }
