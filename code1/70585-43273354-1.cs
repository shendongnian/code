    public static class Selectlists
    {
        public static SelectList EnumSelectlist<TEnum>(bool indexed = false) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(item => new SelectListItem
            {
                Text = GetEnumDescription(item as Enum),
                Value = indexed ? Convert.ToInt32(item).ToString() : item.ToString()
            }).ToList(), "Value", "Text");
        }
        // NOTE: returns Descriptor if there is no Description
        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
