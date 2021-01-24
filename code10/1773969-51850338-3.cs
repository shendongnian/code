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
        private static void OnSettingsChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (UserControl1)d;
            var newSettings = (string)e.NewValue;
            //Optionally do something when Settings changed
        }
    }
