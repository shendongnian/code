    public class ValidatingTextBox : TextBox
    {
        private bool _inEvents;
        private string _textBefore;
        private int _selectionStart;
        private int _selectionLength;
        public event EventHandler<ValidateTextEventArgs> ValidateText;
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (_inEvents)
                return;
            _selectionStart = SelectionStart;
            _selectionLength = SelectionLength;
            _textBefore = Text;
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (_inEvents)
                return;
            _inEvents = true;
            var ev = new ValidateTextEventArgs(Text);
            OnValidateText(this, ev);
            if (ev.Cancel)
            {
                Text = _textBefore;
                SelectionStart = _selectionStart;
                SelectionLength = _selectionLength;
            }
            _inEvents = false;
        }
        protected virtual void OnValidateText(object sender, ValidateTextEventArgs e) => ValidateText?.Invoke(this, e);
    }
    public class ValidateTextEventArgs : CancelEventArgs
    {
        public ValidateTextEventArgs(string text) => Text = text;
        public string Text { get; }
    }
    public class Int32TextBox : ValidatingTextBox
    {
        protected override void OnValidateText(object sender, ValidateTextEventArgs e) => e.Cancel = !int.TryParse(e.Text, out var value);
    }
    public class Int64TextBox : ValidatingTextBox
    {
        protected override void OnValidateText(object sender, ValidateTextEventArgs e) => e.Cancel = !long.TryParse(e.Text, out var value);
    }
    public class DoubleTextBox : ValidatingTextBox
    {
        protected override void OnValidateText(object sender, ValidateTextEventArgs e) => e.Cancel = !double.TryParse(e.Text, out var value);
    }
    public class SingleTextBox : ValidatingTextBox
    {
        protected override void OnValidateText(object sender, ValidateTextEventArgs e) => e.Cancel = !float.TryParse(e.Text, out var value);
    }
    public class DecimalTextBox : ValidatingTextBox
    {
        protected override void OnValidateText(object sender, ValidateTextEventArgs e) => e.Cancel = !decimal.TryParse(e.Text, out var value);
    }
