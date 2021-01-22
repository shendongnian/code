    public partial class KeyboardForm : Form
    {
        public delegate void ButtonPressed(string keyPressed);
        public event ButtonPressed ButtonPressedEvent;
        public KeyboardForm()
        {
            InitializeComponent();
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if ((ButtonPressedEvent != null))
                {
                    ButtonPressedEvent("{"+button.Text+"}");
                }
            }
        }
    }
