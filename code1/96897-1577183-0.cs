    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value is string)
                {
                    return GetEnumValue(myVal, (string)value);
                }
                if (value is Enum)
                {
                    return GetEnumDescription((Enum)value);
                }
                return base.ConvertFrom(context, culture, value);
            }
