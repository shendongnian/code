    class MyContractResolver: DefaultContractResolver 
    {
   
      protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = String.Compare(property.PropertyName, "Value") != 0;
                return property;
            }
    }
