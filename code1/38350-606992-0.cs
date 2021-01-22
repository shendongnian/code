    using System;
    using System.ComponentModel;
    static class Program
    {
        static void Main()
        {
            TypeDescriptor.AddAttributes(typeof(Guid), new TypeConverterAttribute(
                typeof(MyGuidConverter)));
    
            Guid guid = Guid.NewGuid();
            TypeConverter conv = TypeDescriptor.GetConverter(guid);
            byte[] data = (byte[])conv.ConvertTo(guid, typeof(byte[]));
            Guid newGuid = (Guid)conv.ConvertFrom(data);
        }
    }
    
    class MyGuidConverter : GuidConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(byte[]) || base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(byte[]) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value != null && value is byte[])
            {
                return new Guid((byte[])value);
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(byte[]))
            {
                return ((Guid)value).ToByteArray();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
