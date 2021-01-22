    using System;
    using System.Windows.Data;
    namespace NumberedListBox
    {
        public class RowNumberConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                CollectionViewSource collectionViewSource = parameter as CollectionViewSource;
                
                int counter = 1;
                foreach (object item in collectionViewSource.View)
                {
                    if (item == value)
                    {
                        return counter.ToString();
                    }
                    counter++;
                }
                return string.Empty;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
