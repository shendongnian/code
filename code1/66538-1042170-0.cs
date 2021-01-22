    public class ReadOnlyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            base.OnKeyDown(e);
        }
    }
