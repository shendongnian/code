    public class LabelExtension 
    {
        public static readonly DependencyProperty SecondContentProperty = DependencyProperty.RegisterAttached(
            "SecondContent", typeof(object), typeof(LabelExtension));
        public static void SetSecondContent(UIElement element, object value)
        {
            element.SetValue(SecondContentProperty, value);
        }
        public static object GetSecondContent(UIElement element)
        {
            return (object)element.GetValue(SecondContentProperty);
        }
    }
