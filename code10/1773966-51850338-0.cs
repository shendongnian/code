    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    
        public static readonly DependencyProperty SettingsProperty = DependencyProperty.Register("Settings", typeof(string), typeof(UserControl1), null);
        public string Settings
        {
            get { return (string)GetValue(SettingsProperty); }
            set { SetValue(SettingsProperty, value); }
        }
    }
