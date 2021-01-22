    public static class TypeExtentions
    {
        public static bool ImplicitlyConvertsTo(this Type type, Type destinationType)
        {
            if (type == destinationType)
                return true;
            return (from method in type.GetMethods(BindingFlags.Static |
                                                   BindingFlags.Public)
                    where method.Name == "op_Implicit" &&
                          method.ReturnType == destinationType
                    select method
                    ).Count() > 0;
        }
    }
