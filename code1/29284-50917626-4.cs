    public abstract class RegexedTextBox : ValidatedTextBox {
        private readonly Regex m_regex;
        protected RegexedTextBox(string regExpString) {
            m_regex = new Regex(regExpString);
        }
        protected override bool IsValid(string text) {
            return m_regex.IsMatch(Text);
        }
    }
