    public class ValidatedTextBox : TextBox  
    {  
        public ValidatedTextBox()  
        {
        }
        public static readonly DependencyProperty IsSpaceAllowedProperty =  
            DependencyProperty.Register("IsSpaceAllowed", typeof(bool), typeof(ValidatedTextBox));  
        public bool IsSpaceAllowed
        {
            get { return (bool)base.GetValue(IsSpaceAllowedProperty); }
            set { base.SetValue(IsSpaceAllowedProperty, value); }
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (!IsSpaceAllowed && (e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }
    }
