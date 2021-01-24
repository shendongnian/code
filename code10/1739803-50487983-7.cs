    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    
    namespace TestWpf
    {
        class SubstractorConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var dbls = values.OfType<double>().ToArray();
                if (dbls.Length != 2)
                    return null;
    
                return dbls[0] - dbls[1];
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
