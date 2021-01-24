    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace WpfApplication13
    {
        public class AngleConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                double width = values[0] as double? ?? 0;
                double height = values[1] as double? ?? 0;
                double angleRadians = Math.Atan2(height, width);
                return new RotateTransform {Angle = - angleRadians * 180.0 / Math.PI};
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
