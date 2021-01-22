    public interface ITextBox
    {
        public string Text {get; set;}
    }
    
    public class TextBoxAdapter : ITextBox
    {
        private readonly System.Windows.Forms.TextBox _textBox;
        public TextBoxAdapter(System.Windows.Forms.TextBox textBox)
        {
            _textBox = textBox;
        }
    
        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }
    }
    
    public class YourClass
    {
        private ITextBox _textBox;
        public YourClass(ITextBox textBox)
        {
            _textBox = textBox;
        }
     
        public void DoSomething()
        {
            _textBox.Text = "twiddleMe";
        }
    }
