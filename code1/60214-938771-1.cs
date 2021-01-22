        class HexConverter : TypeConverter // untested
        {
            public override object ConvertTo(ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture,
                object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return ToHexString((byte[])value);
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
