    public class YesOrNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is YesOrNo yesOrNo)
            {
                switch (yesOrNo)
                {
                    case YesOrNo.Yes:
                        return true;
                    case YesOrNo.No:
                    default:
                        return false;
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
                return boolean ? YesOrNo.Yes : YesOrNo.No;
            return value;
        }
    }
