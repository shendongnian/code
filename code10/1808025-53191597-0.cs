    public class MyControl : ContentControl
    {
        public string C1
        {
            get { return (string)GetValue(C1Property); }
            set { SetValue(C1Property, value); }
        }
        public static readonly DependencyProperty C1Property = DependencyProperty.Register(nameof(C1), typeof(string), typeof(MyControl));
        public string C2
        {
            get { return (string)GetValue(C2Property); }
            set { SetValue(C2Property, value); }
        }
        public static readonly DependencyProperty C2Property = DependencyProperty.Register(nameof(C2), typeof(string), typeof(MyControl));
    }
