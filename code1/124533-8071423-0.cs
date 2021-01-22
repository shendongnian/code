    public class AutoSelectAll
    {
        public static bool GetIsEnabled(DependencyObject obj) 
        { 
            return (bool)obj.GetValue(IsEnabledProperty); 
        } 
        public static void SetIsEnabled(DependencyObject obj, bool value) 
        { 
            obj.SetValue(IsEnabledProperty, value);
        }
        static void ue_Loaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null)
                return;
            ue.GotFocus += ue_GotFocus;
            ue.GotMouseCapture += ue_GotMouseCapture;
        }
        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null)
                return;
            //ue.Unloaded -= ue_Unloaded;
            ue.GotFocus -= ue_GotFocus;
            ue.GotMouseCapture -= ue_GotMouseCapture;
        }
        static void ue_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                (sender as TextBox).SelectAll();
            }
            e.Handled = true;
        }
        static void ue_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (sender is TextBox)
            {
                (sender as TextBox).SelectAll();
            }
            e.Handled = true;
        }
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
            typeof(AutoSelectAll), new UIPropertyMetadata(false, IsEnabledChanged));
        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ue = d as FrameworkElement;
            if (ue == null)
                return;
            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.Loaded += ue_Loaded;
            }
        }
    } 
