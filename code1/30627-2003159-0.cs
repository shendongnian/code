    public static class StaticClass
    {
        public static string GetEnumDescription(Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;
            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                        typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();
            return description;
        }
        public static List<string> GetEnumFormattedNames<TEnum>()
        {
            var enumType = typeof(TEnum);
            if (enumType == typeof(Enum))
                throw new ArgumentException("typeof(TEnum) == System.Enum", "TEnum");
            if (!(enumType.IsEnum))
                throw new ArgumentException(String.Format("typeof({0}).IsEnum == false", enumType), "TEnum");
            List<string> formattedNames = new List<string>();
            var list = Enum.GetValues(enumType).OfType<TEnum>().ToList<TEnum>();
            foreach (TEnum item in list)
            {
                formattedNames.Add(GetEnumDescription(item as Enum));
            }
            return formattedNames;
        }
    }
