    public partial class MainWindow : Window    
    {
        public static DependencyProperty LineNoProperty =
            DependencyProperty.RegisterAttached("LineNo"
                , typeof(int)
                , typeof(MainWindow)
                , new FrameworkPropertyMetadata(null)
            { BindsTwoWayByDefault = true });
        public static int GetDoc(DependencyObject obj)
        {
            return (int)obj.GetValue(LineNoProperty);
        }
        public static void SetDoc(DependencyObject obj, int value)
        {
            obj.SetValue(LineNoProperty, value);
        }
