        public class FocusChangedBehavior : Behavior<UIElement>
        {
            public static readonly DependencyProperty IsFocusedProperty = 
               DependencyProperty.Register(
               nameof(IsFocused),
               typeof(bool),
               typeof(FocusChangedBehavior),
               new FrameworkPropertyMetadata(default(bool), 
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            public bool IsFocused
            {
                get { return (bool)this.GetValue(IsFocusedProperty); }
                set { this.SetValue(IsFocusedProperty, value); }
            }
            /// <inheritdoc />
            protected override void OnAttached()
            {
                this.AssociatedObject.GotFocus += this.AssociatedObjectFocused;
                this.AssociatedObject.LostFocus += this.AssociatedObjectUnfocused;
            }
            /// <inheritdoc />
            protected override void OnDetaching()
            {
                this.AssociatedObject.GotFocus -= this.AssociatedObjectFocused;
                this.AssociatedObject.LostFocus -= this.AssociatedObjectUnfocused;
            }
            private void AssociatedObjectFocused(object sender, RoutedEventArgs e)
            {
                this.IsFocused = true;
            }
            private void AssociatedObjectUnfocused(object sender, RoutedEventArgs e)
            {
                this.IsFocused = false;
            }
        }
