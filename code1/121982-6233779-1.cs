        /// <summary> Mimics the behavior of string.substring for use in XAML </summary>
    public class SubStringConverter : IValueConverter
    {
        /// <summary> the zero-based starting character position </summary>
        public int StartIndex { get; set; }
        /// <summary> The number of characters in the substring </summary>
        public int Length { get; set; }
        /// <summary> shows "..." if value was truncated after StartIndex</summary>
        public bool ShowEllipse { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string valueString = value as string;
            if (string.IsNullOrWhiteSpace(valueString) == false)
            {
                if (Length > 0 && Length < (valueString.Length + StartIndex))
                {
                    if (ShowEllipse)
                        return valueString.Substring(StartIndex, Length - 3) + "...";
                    else
                        return valueString.Substring(StartIndex, Length);
                }
                else if (StartIndex < valueString.Length)
                    return valueString.Substring(StartIndex);
                else
                    return ""; //because startIndex must be past the length of the string
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
