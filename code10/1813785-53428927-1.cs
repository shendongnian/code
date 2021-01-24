    class CustomVisibilityToBool : MarkupExtension, IValueConverter
    {
        public bool VisibleValue { get; set; }
        public bool CollapsedValue { get; set; }
        public bool HiddenValue { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as Visibility?) == Visibility.Visible) return VisibleValue;
            else if ((value as Visibility?) == Visibility.Hidden) return HiddenValue;
            else if ((value as Visibility?) == Visibility.Collapsed) return CollapsedValue;
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as bool?) == VisibleValue) return Visibility.Visible;
            else if ((value as bool?) == HiddenValue) return Visibility.Hidden;
            else if ((value as bool?) == CollapsedValue) return Visibility.Collapsed;
            return Binding.DoNothing;
        }
    }
