    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace WpfApplication2
    {
        public class RadioButtonCustomStringConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if(values != null)
                {
                    var result = "";
                    for (int i = 0; i < values.Length; i++)
                        if (values[i] as bool? == true)
                            result += (i % 3);
                    if (result.Length < 3)
                        return "You haven't selected three items.";
                    else
                        return result;
                }
                return null;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
