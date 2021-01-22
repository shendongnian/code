    public class ValueProxy : FrameworkElement
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(ValueProxy), new PropertyMetadata(OnPropertyChanged));
        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValueProxy obj = (ValueProxy)d;
            if (obj.PropertyChanged != null)
            {
                obj.PropertyChanged(obj, null);
            }
        }
        public event EventHandler PropertyChanged;
    }
