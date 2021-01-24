    public partial class UserControl1 : UserControl
    {
        public enum StyleSelector
        {
            Style1,
            Style2,
            Style3
        }
        public static DependencyProperty SelectedStyleProperty =
            DependencyProperty.Register("SelectedStyle", typeof(StyleSelector), typeof(UserControl1));
        public UserControl1()
        {
            InitializeComponent();
        }
        public StyleSelector SelectedStyle
        {
            get => (StyleSelector)GetValue(SelectedStyleProperty);
            set => SetValue(SelectedStyleProperty, value);
        }
    }
