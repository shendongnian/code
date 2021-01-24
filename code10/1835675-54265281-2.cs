    public class PasswordToHiddenCharactersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                return string.Empty;
            }
            var passwordText = (string)values[0];
            var hidePassword = (bool)values[1];
            if (hidePassword)
            {
                return string.Empty.PadRight(passwordText.Length, '*');
            }
            return passwordText;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new[] { value };
        }
    }
