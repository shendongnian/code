    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace Evidence.OutlookIntegration.AddinLogic.Behaviors
    {
        public class PasswordBinding : Behavior<PasswordBox>
        {
            private readonly SimpleCrypter _crypter = new SimpleCrypter(); // see http://stackoverflow.com/a/10177020 for a wrapper of RijndaelManaged
            // EncryptedPassword
            public string EncryptedPassword { get { return (string)GetValue(EncryptedPasswordProperty); } set { SetValue(EncryptedPasswordProperty, value); } }
            public static readonly DependencyProperty EncryptedPasswordProperty = DependencyProperty.Register("EncryptedPassword", typeof(string), typeof(PasswordBinding));
            // Passphrase
            public string Passphrase { private get { return (string)GetValue(PassphraseProperty); } set { SetValue(PassphraseProperty, value); EncryptPassword(); } }
            public static readonly DependencyProperty PassphraseProperty = DependencyProperty.Register("Passphrase", typeof(string), typeof(PasswordBinding), new FrameworkPropertyMetadata(OnPassphraseChanged));
            protected override void OnAttached()
            {
                AssociatedObject.PasswordChanged += (s, e) => EncryptPassword();
                base.OnAttached();
            }
            private static void OnPassphraseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((PasswordBinding)d).EncryptPassword();
            }
            private void EncryptPassword()
            {
                if (AssociatedObject != null)
                    EncryptedPassword = _crypter.Encrypt(AssociatedObject.Password, Passphrase);
            }
        }
    }
