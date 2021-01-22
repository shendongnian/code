    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox),
            new PropertyMetadata(PasswordChanged));
        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public BindablePasswordBox()
        {
            InitializeComponent();
            PswdBox.PasswordChanged += PswdBox_PasswordChanged;
        }
        private void PswdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var secure = new SecureString();
            foreach (var c in PswdBox.Password)
            {
                secure.AppendChar(c);
            }
            if (Password != secure)
            {
                Password = secure;
            }
        }
        private static void PasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pswdBox = d as BindablePasswordBox;
            if (pswdBox != null && e.NewValue != e.OldValue)
            {
                var newValue = e.NewValue as SecureString;
                if (newValue == null)
                {
                    return;
                }
                var unmanagedString = IntPtr.Zero;
                string newString;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(newValue);
                    newString = Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
                var currentValue = pswdBox.PswdBox.Password;
                if (currentValue != newString)
                {
                    pswdBox.PswdBox.Password = newString;
                }
            }
        }
    }
