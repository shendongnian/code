    using System.Security;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace Evidence.OutlookIntegration.AddinLogic.Behaviors
    {
        /// <summary>
        /// Intermediate class that handles password box binding (which is not possible directly).
        /// </summary>
        public class PasswordBoxBindingBehavior : Behavior<PasswordBox>
        {
            // BoundPassword
            public SecureString BoundPassword { get { return (SecureString)GetValue(BoundPasswordProperty); } set { SetValue(BoundPasswordProperty, value); } }
            public static readonly DependencyProperty BoundPasswordProperty = DependencyProperty.Register("BoundPassword", typeof(SecureString), typeof(PasswordBoxBindingBehavior), new FrameworkPropertyMetadata(OnBoundPasswordChanged));
            protected override void OnAttached()
            {
                this.AssociatedObject.PasswordChanged += AssociatedObjectOnPasswordChanged;
                base.OnAttached();
            }
            /// <summary>
            /// Link up the intermediate SecureString (BoundPassword) to the UI instance
            /// </summary>
            private void AssociatedObjectOnPasswordChanged(object s, RoutedEventArgs e)
            {
                this.BoundPassword = this.AssociatedObject.SecurePassword;
            }
            /// <summary>
            /// Reacts to password reset on viewmodel (ViewModel.Password = new SecureString())
            /// </summary>
            private static void OnBoundPasswordChanged(object s, DependencyPropertyChangedEventArgs e)
            {
                var box = ((PasswordBoxBindingBehavior)s).AssociatedObject;
                if (box != null)
                {
                    if (((SecureString)e.NewValue).Length == 0)
                        box.Password = string.Empty;
                }
            }
        }
    }
