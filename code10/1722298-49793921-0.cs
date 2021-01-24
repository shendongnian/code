        public static DependencyProperty DocProperty =
            DependencyProperty.RegisterAttached("Doc"
                , typeof(HTMLDocument)
                , typeof(MainWindow)
                , new FrameworkPropertyMetadata(null)
            { BindsTwoWayByDefault = true });
        public static HTMLDocument GetDoc(DependencyObject obj)
        {
            return (HTMLDocument)obj.GetValue(DocProperty);
        }
        public static void SetDoc(DependencyObject obj, HTMLDocument value)
        {
            obj.SetValue(DocProperty, value);
        }
