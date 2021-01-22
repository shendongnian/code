    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    namespace MyProject.Behaviors
    {
        public class FocusBehavior : Behavior<Control>
        {
            protected override void OnAttached()
            {
                this.AssociatedObject.Loaded += AssociatedObject_Loaded;
                base.OnAttached();
            }
    
            private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
            {
                this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
                if (this.HasInitialFocus || this.IsFocused)
                {
                    this.GotFocus();
                }
            }
    
            private void GotFocus()
            {
                this.AssociatedObject.Focus();
                if (this.IsSelectAll)
                {
                    if (this.AssociatedObject is TextBox)
                    {
                        (this.AssociatedObject as TextBox).SelectAll();
                    }
                    else if (this.AssociatedObject is PasswordBox)
                    {
                        (this.AssociatedObject as PasswordBox).SelectAll();
                    }
                    else if (this.AssociatedObject is RichTextBox)
                    {
                        (this.AssociatedObject as RichTextBox).SelectAll();
                    }
                }
            }
    
            public static readonly DependencyProperty IsFocusedProperty =
                DependencyProperty.Register(
                    "IsFocused",
                    typeof(bool),
                    typeof(FocusBehavior),
                    new PropertyMetadata(false, 
                        (d, e) => 
                        {
                            if ((bool)e.NewValue)
                            {
                                ((FocusBehavior)d).GotFocus();
                            }
                        }));
    
            public bool IsFocused
            {
                get { return (bool)GetValue(IsFocusedProperty); }
                set { SetValue(IsFocusedProperty, value); }
            }
    
            public static readonly DependencyProperty HasInitialFocusProperty =
                DependencyProperty.Register(
                    "HasInitialFocus",
                    typeof(bool),
                    typeof(FocusBehavior),
                    new PropertyMetadata(false, null));
    
            public bool HasInitialFocus
            {
                get { return (bool)GetValue(HasInitialFocusProperty); }
                set { SetValue(HasInitialFocusProperty, value); }
            }
    
            public static readonly DependencyProperty IsSelectAllProperty =
                DependencyProperty.Register(
                    "IsSelectAll",
                    typeof(bool),
                    typeof(FocusBehavior),
                    new PropertyMetadata(false, null));
    
            public bool IsSelectAll
            {
                get { return (bool)GetValue(IsSelectAllProperty); }
                set { SetValue(IsSelectAllProperty, value); }
            }
    
        }
    }
