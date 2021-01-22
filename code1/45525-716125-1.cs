    namespace EmptyTemplate
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
        }
    
        public class AType { }
    
        public class BType { }
    
        public class TypeConverter : IValueConverter
        {
            public DataTemplate DefaultTemplate { get; set; }
            
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value.GetType() == typeof(AType))
                {
                    return value.ToString();
                }
                return DefaultTemplate;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
