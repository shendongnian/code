    [TypeConverter(typeof(StringFieldConverter))]
    public class StringField
    {
        public StringField() : this("") { }
        public StringField(string value) { Value = value; }
        public string Value { get; private set; }
    }
    class StringFieldConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string)
                || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value)
        {
            string s = value as string;
            if (s != null) return new StringField(s);
            return base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertTo(
            ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string)
                || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null
                && value is StringField)
            {
                return ((StringField)value).Value;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
