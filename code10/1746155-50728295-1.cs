    public partial class Form2 : Form
    {
        Form1 form1; // Reference to form1
        public Form2(Form1 form1)
        {
            this.form1 = form1; // We initialize form1
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // we call openimage from form1
            form1.openImage(130, 140);
        }
    }
