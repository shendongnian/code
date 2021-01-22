    public static Expected GetAttributeValue<T, Expected>(this Enum enumeration, Func<T, Expected> expression)
        where T : Attribute
    {
        T attribute =
          enumeration
            .GetType()
            .GetMember(enumeration.ToString())
            .Where(member => member.MemberType == MemberTypes.Field)
            .FirstOrDefault()
            .GetCustomAttributes(typeof(T), false)
            .Cast<T>()
            .SingleOrDefault();
        if (attribute == null)
            return default(Expected);
        return expression(attribute);
    }
