    public class EnumDescriptionConverter<T> : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(T) || sourceType == typeof(string));
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(T) || destinationType == typeof(string));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            Type typeFrom = context.Instance.GetType();
            if (typeFrom == typeof(string))
            {
                return (object)GetValue((string)context.Instance);
            }
            else if (typeFrom is T)
            {
                return (object)GetDescription((T)context.Instance);
            }
            else
            {
                throw new ArgumentException("Type converting from not supported: " + typeFrom.FullName);
            }
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            Type typeFrom = value.GetType();
            if (typeFrom == typeof(string) && destinationType == typeof(T))
            {
                return (object)GetValue((string)value);
            }
            else if (typeFrom == typeof(T) && destinationType == typeof(string))
            {
                return (object)GetDescription((T)value);
            }
            else
            {
                throw new ArgumentException("Type converting from not supported: " + typeFrom.FullName);
            }
        }
        public string GetDescription(T en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
        public T GetValue(string description)
        {
            foreach (T val in Enum.GetValues(typeof(T)))
            {
                string currDescription = GetDescription(val);
                if (currDescription == description)
                {
                    return val;
                }
            }
            throw new ArgumentOutOfRangeException("description", "Argument description must match a Description attribute on an enum value of " + typeof(T).FullName);
        }
    }
