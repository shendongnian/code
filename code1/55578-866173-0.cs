    public class Converter : IValueConverter
    {
        private Type _type = null;
        public Type Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    if (value.GetInterface("IValueConverter") != null)
                    {
                        _type = value;
                        _converter = null;
                    }
                    else
                    {
                        throw new ArgumentException(
                            string.Format("Type {0} doesn't implement IValueConverter", value.FullName),
                            "value");
                    }
                }
            }
        }
        private IValueConverter _converter = null;
        private void CreateConverter()
        {
            if (_converter == null)
            {
                if (_type != null)
                {
                    _converter = Activator.CreateInstance(_type) as IValueConverter;
                }
                else
                {
                    throw new InvalidOperationException("Converter type is not defined");
                }
            }
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CreateConverter();
            return _converter.Convert(value, targetType, parameter, culture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CreateConverter();
            return _converter.ConvertBack(value, targetType, parameter, culture);
        }
        #endregion
    }
