    public class MyFunkyControl : ContentControl
    {
        public static readonly DependencyProperty HeadingProperty =
            DependencyProperty.Register("Heading", typeof(string),
            typeof(HeadingContainer), new PropertyMetadata(HeadingChanged));
        private static void HeadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HeadingContainer) d).Heading = e.NewValue as string;
        }
        public string Heading { get; set; }
    }
