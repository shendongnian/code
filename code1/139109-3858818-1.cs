    public partial class ToggleButtonEx : ToggleButton
    {
        public ToggleButtonEx()
        {
            InitializeComponent();            
        }
        public static readonly DependencyProperty EnabledUncheckedProperty =
            DependencyProperty.Register(
            "EnabledUnchecked",
            typeof(ImageSource),
            typeof(ToggleButtonEx),
            new PropertyMetadata(onEnabledUncheckedChangedCallback));
        public ImageSource EnabledUnchecked
        {
            get { return (ImageSource)GetValue(EnabledUncheckedProperty); }
            set { SetValue(EnabledUncheckedProperty, value); }
        }
        static void onEnabledUncheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {
            //do something if needed
        }
        public static readonly DependencyProperty DisabledUncheckedProperty =
            DependencyProperty.Register(
            "DisabledUnchecked",
            typeof(ImageSource),
            typeof(ToggleButtonEx),
            new PropertyMetadata(onDisabledUncheckedChangedCallback));
        public ImageSource DisabledUnchecked
        {
            get { return (ImageSource)GetValue(DisabledUncheckedProperty); }
            set { SetValue(DisabledUncheckedProperty, value); }
        }
        static void onDisabledUncheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {
            //do something if needed
        }
        public static readonly DependencyProperty EnabledCheckedProperty =
            DependencyProperty.Register(
            "EnabledChecked",
            typeof(ImageSource),
            typeof(ToggleButtonEx),
            new PropertyMetadata(onEnabledCheckedChangedCallback));
        public ImageSource EnabledChecked
        {
            get { return (ImageSource)GetValue(EnabledCheckedProperty); }
            set { SetValue(EnabledCheckedProperty, value); }
        }
        static void onEnabledCheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {
            //do something if needed
        }
        private void ToggleButton_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ChangeImage();
        }
        private void ToggleButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ChangeImage();
        }
        private void ToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeImage();
        }
        private void ChangeImage()
        {
            if (IsEnabled)
            {
                if(IsChecked == true)
                    ButtonImage.Source = EnabledChecked;
                else
                    ButtonImage.Source = EnabledUnchecked;
            }
            else
            {
                ButtonImage.Source = DisabledUnchecked;
            }
        }
    }
