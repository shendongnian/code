    public partial class Form1 : Form
    {
        private KeyboardForm mKeyboardForm = new KeyboardForm();
        private bool mIsKeyboardCode = false;
        public Form1()
        {
            InitializeComponent();
            mKeyboardForm.ButtonPressedEvent += new KeyboardForm.ButtonPressed(KeyboardFormButtonPressedEvent);
        }
        void KeyboardFormButtonPressedEvent(string/*Keys*/ keyPressed)
        {
            mIsKeyboardCode = true;
            textBox1.Focus();
            SendKeys.SendWait(keyPressed.ToString());
            mKeyboardForm.Focus();
            mIsKeyboardCode = false;
        }
        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (!mKeyboardForm.Visible)
                {
                    mKeyboardForm.Show(this);
                    e.Handled = true;
                }
            }
            else if (!mIsKeyboardCode)
            {
                mKeyboardForm.Hide();
            }
        }
    }
