    public partial class Window1 : Window
    {
        public static readonly DependencyProperty MyProperty2Property =
            DependencyProperty.Register("MyProperty2", typeof(string), typeof(Window1), new UIPropertyMetadata(string.Empty));
        public static readonly DependencyProperty MyProperty1Property =
            DependencyProperty.Register("MyProperty1", typeof(string), typeof(Window1), new UIPropertyMetadata(string.Empty));
        public Window1()
        {
            InitializeComponent();
        }
        public string MyProperty1
        {
            get { return (string)GetValue(MyProperty1Property); }
            set { SetValue(MyProperty1Property, value); }
        }
        public string MyProperty2
        {
            get { return (string)GetValue(MyProperty2Property); }
            set { SetValue(MyProperty2Property, value); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set MyProperty1 and 2
            this.MyProperty1 = "Hello";
            this.MyProperty2 = "World";
        }
    }
