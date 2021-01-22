    [TypeConverter(typeof(MyColorConverter))]
    public class MyColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    class MyColorConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
             Type sourceType)
        {
            return sourceType == typeof(string)
                || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, 
            System.Globalization.CultureInfo culture, object value)
        {
            if (value != null && value is string)
            {
                string[] parts = ((string)value).Split(new string[] {"--"},
                   StringSplitOptions.None);
                MyColor color = new MyColor();
                if(parts.Length > 0) color.Id = int.Parse(parts[0]);
                if(parts.Length > 1) color.Name = parts[1];
                return color;
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context,
             Type destinationType)
        {
            return destinationType == typeof(string)
                || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                MyColor color = (MyColor)value;
                return color.Id + "--" + color.Name;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
