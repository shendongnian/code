    [TypeConverter(typeof(PercentageConverter))]
    public struct Percentage
    {
        public double Value;
    
        public Percentage( double value )
        {
            Value = value;
        }
    
        public Percentage( string value )
        {
            var pct = (Percentage) TypeDescriptor.GetConverter(GetType()).ConvertFromString(value);
            Value = pct.Value;
        }
    
        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture);
        }
    
        public string ToString(CultureInfo Culture)
        {
            return TypeDescriptor.GetConverter(GetType()).ConvertToString(null, Culture, this);
        }
    }
    
    public class PercentageConverter : TypeConverter
    {
        static TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
    
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return conv.CanConvertFrom(context, sourceType);
        }
    
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Percentage)) {
                return true;
            }
    
            return conv.CanConvertTo(context, destinationType);
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value == null) {
                return new Percentage();
            }
    
            if (value is string) {
                string s = value as string;
                s = s.TrimEnd(' ', '\t', '\r', '\n');
    
                var percentage = s.EndsWith(culture.NumberFormat.PercentSymbol);
                if (percentage) {
                    s = s.Substring(0, s.Length - culture.NumberFormat.PercentSymbol.Length);
                }
    
                double result = (double) conv.ConvertFromString(s);
                if (percentage) {
                    result /= 100;
                }
    
                return new Percentage(result);
            }
    
            return new Percentage( (double) conv.ConvertFrom( context, culture, value ));
        }
    
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (!(value is Percentage)) {
                throw new ArgumentNullException("value");
            }
    
            var pct = (Percentage) value;
    
            if (destinationType == typeof(string)) {
                return conv.ConvertTo( context, culture, pct.Value * 100, destinationType ) + culture.NumberFormat.PercentSymbol;
            }
    
            return conv.ConvertTo( context, culture, pct.Value, destinationType );
        }
    }
    
