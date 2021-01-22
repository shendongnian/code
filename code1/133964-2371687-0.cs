    CustomAttributeBuilder ct = AddAttributesToMemberInfo(methodInfo);
    if (ct != null)
    {
        methodBuilder.SetCustomAttribute(ct);
    }
    CustomAttributeBuilder AddAttributesToMemberInfo(MemberInfo oldMember)
    {
        CustomAttributeBuilder ct = null;
        IList<CustomAttributeData> customMethodAttributes = CustomAttributeData.GetCustomAttributes(oldMember);
        foreach (CustomAttributeData att in customMethodAttributes)
        {
            List<object> namedFieldValues = new List<object>();
            List<FieldInfo> fields = new List<FieldInfo>();
            List<object> constructorArguments = new List<object>();
            foreach (CustomAttributeTypedArgument cata in att.ConstructorArguments)
            {
                constructorArguments.Add(cata.Value);
            }
            if (att.NamedArguments.Count > 0)
            {
                FieldInfo[] possibleFields = att.GetType().GetFields();
                foreach (CustomAttributeNamedArgument cana in att.NamedArguments)
                {
                    for (int x = 0; x < possibleFields.Length; x++)
                    {
                        if (possibleFields[x].Name.CompareTo(cana.MemberInfo.Name) == 0)
                        {
                            fields.Add(possibleFields[x]);
                            namedFieldValues.Add(cana.TypedValue.Value);
                        }
                    }
                }
            }
            
            if (namedFieldValues.Count > 0)
            {
                ct = new CustomAttributeBuilder(att.Constructor, constructorArguments.ToArray(), fields.ToArray(), namedFieldValues.ToArray());
            }
            else
            {
                ct = new CustomAttributeBuilder(att.Constructor, constructorArguments.ToArray());
            }
           
        }
        return ct;
    }
