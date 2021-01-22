    public class CultureHelper : DependencyObject
    {
        public string Culture
        {
            get { return (string)GetValue(CultureProperty); }
            set { SetValue(CultureProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CultureProperty =
            DependencyProperty.RegisterAttached("Culture", typeof(string), typeof(CultureHelper), new FrameworkPropertyMetadata("en", CultureChanged));
        private static void CultureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //For testing purposes in designer only 
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo((string)e.NewValue);
            }
        }
        public static void SetCulture(DependencyObject element, string value)
        {
            element.SetValue(CultureProperty, value);
        }
        public static string GetCulture(DependencyObject element)
        {
            return (string)element.GetValue(CultureProperty);
        }
    }
