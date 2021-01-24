    public class BaseConverter<TConvert, TConvertBack> : IValueConverter
    {
        protected CultureInfo CurrentCulture { get; set;}
        public virtual object Convert(object value, Type targetType, object parameters, CultureInfo culture)
        {
            CurrentCulture = culture;
            
            // Generic methods to check types and conversions....
            var typedValue = (TConvert)value;
            
            return Convert(typedValue, targetType, parameters);
         }
         protected abstract Convert(TConvert value, Type targetType, object parameters);
         /// Implement rest of interfaces/generic
    }
