    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;
        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }
        public override void WriteLine(string value)
        {
            // When character data is written, append it to the text box.
            // using Invoke so it works in a different thread as well
            _output.Invoke((Action)(() => _output.AppendText(value+"\r\n")));
        }
	}
			
