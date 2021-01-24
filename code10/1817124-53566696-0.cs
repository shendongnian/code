    public class StringToBoolConvert : IValueConverter
    {
        public string TrueString { get; set; } = "true";
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (TrueString.Equals(value?.ToString()))
            {
                return true;
            }
            return false;
        }
        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
