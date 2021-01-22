    public class FirstForm : Form
    {
        private TextBox nameInput;
        public TextBox NameInput { get { return nameInput; } }
        ...
    }
    public class SecondForm : Form
    {
        private TextBox otherNameInput;
        private FirstForm firstForm;
        public void CopyValue()
        {
            firstForm.NameInput.Text = otherNameInput.Text;
        }
    }
