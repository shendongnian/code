    public class YesOrNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is YesOrNo yesOrNo && yesOrNo == YesOrNo.Yes) ? true : false;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (value is bool isYes && isYes) ? YesOrNo.Yes : YesOrNo.No;
    }
