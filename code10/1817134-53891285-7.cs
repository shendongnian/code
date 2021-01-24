    public class CategoryConverter : TypeConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var svc = new CategoryService();
            return new StandardValuesCollection(svc.GetAll().ToList());
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null && value.GetType() == typeof(string))
            {
                var v = $"{value}";
                var id = int.Parse(v.Split('-')[0].Trim());
                var svc = new CategoryService();
                return svc.GetAll().Where(x => x.Id == id).FirstOrDefault();
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
