        public class ReadOnlyCheckBoxControl : System.Windows.Controls.Button
    {
        public static DependencyProperty IsCheckedProperty;
        public ReadOnlyCheckBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ReadOnlyCheckBoxControl), new FrameworkPropertyMetadata(typeof(ReadOnlyCheckBoxControl)));
        }
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        static ReadOnlyCheckBoxControl()
        {
            IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(ReadOnlyCheckBoxControl));
        }
    }
