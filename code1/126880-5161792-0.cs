        public class FocusElementAfterClickBehavior : Behavior<ButtonBase>
    {
        private ButtonBase _AssociatedButton;
        protected override void OnAttached()
        {
            _AssociatedButton = AssociatedObject;
            _AssociatedButton.Click += AssociatedButtonClick;
        }
        protected override void OnDetaching()
        {
            _AssociatedButton.Click -= AssociatedButtonClick;
        }
        void AssociatedButtonClick(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(FocusElement);
        }
        public Control FocusElement
        {
            get { return (Control)GetValue(FocusElementProperty); }
            set { SetValue(FocusElementProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FocusElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusElementProperty =
            DependencyProperty.Register("FocusElement", typeof(Control), typeof(FocusElementAfterClickBehavior), new UIPropertyMetadata());
    }
