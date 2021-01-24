    public class Form1: Form
    {
        static Form1 _instance;
        public Form()
        {
            _instance = this;
            InitializeComponents();
        }
        public static void SomeStaticMethod()
        {
            _instance.richTextBox1.Text = "whatever";
        }
    }
