    public class BConverter : ExpandableObjectConverter
    {
        B[] values = new B[] { new B { C = "Something" }, new B { C = "Something else" } };
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, 
            System.Globalization.CultureInfo culture, object value)
        {
            var result = values.Where(x => $"{x}" == $"{value}").FirstOrDefault();
            if (result != null)
                return result.Clone();
            return base.ConvertFrom(context, culture, value);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext c)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext c)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext c)
        {
            return new StandardValuesCollection(values);
        }
    }
