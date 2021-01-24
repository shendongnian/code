    public class Conv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            VisualBrush result = new VisualBrush();
            result.Stretch = Stretch.Fill;
            StackPanel container = new StackPanel();
            container.Orientation = Orientation.Horizontal;
            
            //Generate a colored rectangle for each day.
            //I just use some random values for illustration.
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 20;
                rect.Height = 20;
                rect.Fill = rnd.Next() % 2 == 0 ? Brushes.Red : Brushes.Green;
                container.Children.Add(rect);
            }
            result.Visual = container;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
