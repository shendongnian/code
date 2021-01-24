    public class TextBox : Control
    {
        public string Text { get; set; }
    }
    public class TextBoxBuilder : ControlBuilder<TextBoxBuilder, TextBox>
    {
        public TextBoxBuilder Text(string text)
        {
            control.Text = text;
            return this;
        }
    }
