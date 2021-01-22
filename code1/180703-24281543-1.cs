    c.DataBindings.Add("Checked", dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged );
    
    
    class Someclass
    {
    [TypeConverter(typeof(IntBoolConverter))]
            public int p_isEnable
            {
                get { return nc_isEnable; }
                set { m_isEnable= value); }
            }
    }
     public class IntBoolConverter:TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
    
                if (sourceType == typeof(bool))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }
    
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(int))
                {
                    return true;
                }
                return base.CanConvertFrom(context, destinationType);
            }
    
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is bool)
                {
                    var objectToInt = value.ObjectToBool();
                    return objectToInt;
                }
                return base.ConvertFrom(context, culture, value);
            }
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(bool))
                {
                    return value.ObjectToBool();
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
