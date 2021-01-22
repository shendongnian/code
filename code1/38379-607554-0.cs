    public class BasicComponentTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            bool canConvert = base.CanConvertTo(context, destinationType);
            if (!canConvert &&
                (destinationType == typeof(InstanceDescriptor))
            {
                canConvert = true;
            }
            return canConvert;
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object conversion = null;
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
    
            BasicComponent component = value as BasicComponent;
            if (basicComponent != null)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                   // Note that we convert the blobs to an array as this makes for nicer persisted code output.
                   // Without it, we might just get a resource blob which is not human-readable.
                   conversion = new InstanceDescriptor(
                       typeof(BasicComponent).GetConstructor(new Type[] { typeof(IEnumerable<Blob>) }),
                       new object[] { basicComponent.Blobs.ToArray() },
                       true);
                }
            }
            if (conversion == null)
            {
                conversion = base.ConvertTo(context, culture, value, destinationType);
            }
            return conversion;
        }
    }
