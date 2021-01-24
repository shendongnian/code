    public class CustomWindow : Window
    {
        public CustomWindow()
        {
            Loaded += CustomWindow_Loaded;
        }
        private void CustomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;
            Loaded -= CustomWindow_Loaded;
        }
    }
