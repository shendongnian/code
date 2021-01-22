    public class MyHttpRuntimeCacheConverter : System.ComponentModel.TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         CultureInfo culture, object value,
                                         Type destinationType)
        {
            return HttpRuntime.Cache;
        }
    }
