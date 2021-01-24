        using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApp34
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class MyConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return string.Format(parameter as string, values);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        namespace Statics
        {
            public class Strings
            {
                public static string Val1 { get; set; } = "Val_1";
                public static string Val2 { get; set; } = "Val_2";
            }
        }
    }
