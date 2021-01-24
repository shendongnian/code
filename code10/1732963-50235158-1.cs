    public class CheckoutConverter : IValueConverter
    {
        public object Convert(object entity, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Baseentity = entity as TblBase;
            if (Baseentity.COID == MainWindow.LocalUser.ID)
            {
                return Brushes.Green;
            }
            else if (Baseentity.COID == 0)
            {
                return Brushes.Transparent;
            }
            else if (Baseentity.COID != 0)
            {
                return Brushes.Black;
            }
            else
                return Brushes.Purple;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
