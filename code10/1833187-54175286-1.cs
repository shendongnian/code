    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> GetEnumMemberSelectList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.EnumMemberValue(),
                        Value = x.ToString()
                    }), "Value", "Text");
        }
        public static string EnumMemberValue(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            EnumMemberAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute))
                        as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
