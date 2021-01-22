        public static string getEnumResourceString(Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
            EnumResourceAttribute attr = (EnumResourceAttribute)System.Attribute.GetCustomAttribute(fi, typeof(EnumResourceAttribute));
            return (string)HttpContext.GetGlobalResourceObject(attr.BaseName, attr.Key);
        }
