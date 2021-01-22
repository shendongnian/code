    public class NumericTextBox : TextBox
    {
        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            short val;
            if (!Int16.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            else
            {
                base.OnPreviewTextInput(e);
            }
        }
    }
