    public class CompositeParameter : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new CompositeParameter();
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), 
            typeof(string), typeof(CompositeParameter));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ControlProperty = DependencyProperty.Register(nameof(Control),
            typeof(FrameworkElement), typeof(CompositeParameter));
        public FrameworkElement Control
        {
            get { return (FrameworkElement)GetValue(ControlProperty); }
            set { SetValue(ControlProperty, value); }
        }
    }
