    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    
        public static readonly DependencyProperty SettingsProperty 
            = DependencyProperty.Register("Settings", typeof(string), typeof(UserControl1),
                new PropertyMetadata(
                    "DefaultSetting",
                    new PropertyChangedCallback(OnSettingsChanged)));
        public string Settings
        {
            get { return (string)GetValue(SettingsProperty); }
            set { SetValue(SettingsProperty, value); }
        }
        public static void OnSettingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Do something else when settings chnage
        }
    }
