    [ValueConversion(typeof(bool), typeof(System.Windows.Visibility))]
    public class BooleanVisibilityConverter : IValueConverter
    {
        System.Windows.Visibility _visibilityWhenFalse = System.Windows.Visibility.Collapsed;
        /// <summary>
        /// Gets or sets the <see cref="System.Windows.Visibility"/> value to use when the value is false. Defaults to collapsed.
        /// </summary>
        public System.Windows.Visibility VisibilityWhenFalse
        {
            get { return _visibilityWhenFalse; }
            set { _visibilityWhenFalse = value; }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool negateValue;
            Boolean.TryParse(parameter as string, out negateValue);
    
            bool val = negateValue ^ (bool)value;  //Negate the value using XOR
            return val ? System.Windows.Visibility.Visible : _visibilityWhenFalse;
        }
        ...
