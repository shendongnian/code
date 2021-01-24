    var item = attribute.NamedArguments?.Where(x => x.MemberName == "ElementName")
        .Cast<CustomAttributeNamedArgument?>().FirstOrDefault();                
    if (item.HasValue) {
        property.PropertyName = item.Value.MemberName;
        return;
    }
