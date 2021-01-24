    public class DestinationAndOperationModeToDescriptionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
            {
                return DependencyProperty.UnsetValue;
            }
            string destinationCode;
            OperatingMode operatingMode;
            if (values[0] is string && values[1] is OperatingMode)
            {
                destinationCode = values[0] as string;
                operatingMode = (OperatingMode)values[1];
            }
            else if (values[1] is string && values[0] is OperatingMode)
            {
                destinationCode = values[1] as string;
                operatingMode = (OperatingMode)values[0];
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
            var descriptionAttribute =
                typeof(OperatingMode)
                    .GetField(operatingMode.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .OfType<DescriptionAttribute>().FirstOrDefault();
            if (string.IsNullOrEmpty(descriptionAttribute?.Description))
            {
                return destinationCode;
            }
            return descriptionAttribute.Description;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
