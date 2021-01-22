    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TestClass test = new TestClass();
            test.ModifyText(textBox1);
        }
    }
    public class TestClass
    {
        public void ModifyText(TextBox textBox)
        {
            textBox.Text = "New text";
        }
    }
