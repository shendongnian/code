    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
        }
        public static DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(LabelTextBox));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
