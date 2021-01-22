    using NCalc;
    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace MyProject.Utilities.Converters
    {
        public class MathConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo     culture)
            {
                // Parse value into equation and remove spaces
                string expressionString = parameter as string;
                expressionString = expressionString.Replace(" ", "");
                expressionString = expressionString.Replace("@VALUE", value.ToString());
                return new Expression(expressionString).Evaluate();
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
