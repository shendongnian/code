    public class UInt64HexConverter : UInt64Converter
    {
        private static Type typeUInt64 = typeof(UInt64);
    
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
    
            if (((destinationType == typeof(string)) && (value != null)) && typeUInt64.IsInstanceOfType(value))
            {
                UInt64 val = (UInt64)value;
                return "0x" + val.ToString("X");
            }
    
            if (destinationType.IsPrimitive)
            {
                return Convert.ChangeType(value, destinationType, culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
