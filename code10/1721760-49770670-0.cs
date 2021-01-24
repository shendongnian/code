    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        if (typeof(Item).IsAssignableFrom(property.DeclaringType) 
            && property.UnderlyingName == nameof(Item.ItemDescriptions))
        {
            property.Ignored = true;
        }
        return property;
    }
