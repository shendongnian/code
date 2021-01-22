    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty MyContentProperty =
            DependencyProperty.Register("MyContent", typeof(object), typeof(UserControl1));
        public UserControl1()
        {
            InitializeComponent();
        }
        public object MyContent
        {
            get { return GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }
    }
