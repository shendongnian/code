    public class FirstForm : Form
    {
        private TextBox nameInput;
        public string Name
        { 
            get { return nameInput.Text; } 
            set { nameInput.Text = value; }
        }
        ...
    }
    public class SecondForm : Form
    {
        private TextBox otherNameInput;
        private FirstForm firstForm;
        public void CopyValue()
        {
            firstForm.Name = otherNameInput.Text;
        }
    }
