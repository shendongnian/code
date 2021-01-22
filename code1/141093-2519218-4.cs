    public partial class MainForm : Form
    {
        OtherClass otherClass;
        public MainForm()
        {
            /* just two controls -- listBox1 and button1 */
            InitializeComponent();
            otherClass = new OtherClass(this.TextToBox);
        }
        public void TextToBox(string aString)
        {
            listBox1.Items.Add(aString);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            otherClass.SendSomeText();
        }
    }
