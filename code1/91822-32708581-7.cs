    using System.ComponentModel;
    using System.Security;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace BK.WPF.CustomControls
    {
        public partial class BindanblePasswordBox : UserControl
        {
            public static readonly DependencyProperty PasswordProperty =
                DependencyProperty.Register("Password", typeof(SecureString), typeof(BindanblePasswordBox));
    
            public SecureString Password
            {
                get { return (SecureString)GetValue(PasswordProperty); }
                set { SetValue(PasswordProperty, value); }
            }
       
            public BindanblePasswordBox()
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
                Password = secure;
            }
        }
    }
