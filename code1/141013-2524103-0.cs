    public class MyTextBox : TextBox
    {
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.N)
            {
                e.Handled = true;
                Text += '9';
                // Setting Text annoyingly puts SelectionStart at 0
                this.SelectionStart = Text.Length;
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }
    }
