    public class SubmitTextBox : TextBox
    {
        public SubmitTextBox()
            : base()
        {
            PreviewKeyDown += new KeyEventHandler(SubmitTextBox_PreviewKeyDown);
        }
    
        void SubmitTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BindingExpression be = GetBindingExpression(TextBox.TextProperty);
                if (be != null)
                {
                    be.UpdateSource();
                }
            }
        }
    }
