    public class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.LostFocus += new EventHandler(textBox1_LostFocus);
        }
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (closeButton.Focused)
                return;
            // Update the other text boxes here
        }
    }
