    // using System;
    // using System.ComponentModel;
    // using System.Drawing;
    // using System.Globalization;
    sealed class BooleanToColorConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                          Type destinationType)
        {
            return destinationType == typeof(Color);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
                                         CultureInfo culture,
                                         object value, 
                                         Type destinationType)
        {
            return (bool)value ? Color.Green : Color.Red;
        }
    }
