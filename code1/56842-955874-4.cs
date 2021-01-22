        public class StatusToColorConverter : IValueConverter 
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (targetType != typeof(Status))
                    throw new InvalidOperationException("targetType must be Status");
    
                Status status = (Status)value;
    
                switch (status)
                {
                    case Status.New:
                        return Brushes.Black;
                    case Status.Professional:
                        return Brushes.Blue;
                    case Status.Delete:
                        return Brushes.Red;
                    default:
                        return Brushes.Black;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter,  System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            } 
        }
