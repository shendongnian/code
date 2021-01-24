    public class TextBoxFocusBehavior : Behavior<TextBox>
    {
        #region Overrides of Behavior
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
            base.OnAttached();
        }
        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            //TODO Your LostFocus Method here.
        }
        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            //TODO Your GotFocus Method here.
        }
        #endregion
    }
