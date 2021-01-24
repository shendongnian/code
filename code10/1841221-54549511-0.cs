    public class Class1 
    {
        public static readonly DependencyProperty MyMouseOverProperty = DependencyProperty.RegisterAttached(
            "MyMouseOver", typeof(bool), typeof(Class1), new FrameworkPropertyMetadata(false, PropertyChangedCallback)
        );
        public static void SetMyMouseOver(UIElement element, Boolean value)
        {
            element.SetValue(MyMouseOverProperty, value);
        }
        public static bool GetMyMouseOver(UIElement element)
        {
            return (bool)element.GetValue(MyMouseOverProperty);
        }
        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // some code here
        }
    }
