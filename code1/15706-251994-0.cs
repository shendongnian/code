    class IntListConverter : TypeConverter {
        public static List<int> FromString(string value) {
           return new List<int>(
              value
               .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(s => Convert.ToInt32(s))
           );
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor)) {
                List<int> list = (List<int>)value;
                return new InstanceDescriptor(this.GetType().GetMethod("FromString"),
                    new object[] { string.Join(",", list.Select(i => i.ToString()).ToArray()) }
                );
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
