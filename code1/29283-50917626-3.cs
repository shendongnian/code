    public abstract class ValidatedTextBox : TextBox {
        private string m_lastText = string.Empty;
        protected abstract bool IsValid(string text);
        protected sealed override void OnTextChanged(EventArgs e) {
            if (!IsValid(Text)) {
                var pos = SelectionStart - Text.Length + m_lastText.Length;
                Text = m_lastText;
                SelectionStart = Math.Max(0, pos);
            }
            m_lastText = Text;
            base.OnTextChanged(e);
        }
    }
