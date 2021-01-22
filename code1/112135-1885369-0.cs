    public class MySmartExpandableObjectConverter : ExpandableObjectConverter
    {
        TypeConverter actualConverter = null;
    
        private void InitConverter(ITypeDescriptorContext context)
        {
            if (actualConverter == null)
            {
                TypeConverter parentConverter = TypeDescriptor.GetConverter(context.Instance);
                PropertyDescriptorCollection coll = parentConverter.GetProperties(context.Instance);
                PropertyDescriptor pd = coll[context.PropertyDescriptor.Name];
    
                if (pd.PropertyType == typeof(object))
                    actualConverter = TypeDescriptor.GetConverter(pd.GetValue(context.Instance));
                else
                    actualConverter = this;
            }
        }
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            InitConverter(context);
    
            return actualConverter.CanConvertFrom(context, sourceType);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            InitConverter(context);
    
            return actualConverter.ConvertFrom(context, culture, value);
        }
    }
