    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);
            this.Hide();
            form2.Show();
        }
        private void btnShowForm3_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.FormClosed += (o, args) =>
            {
                this.Show();
            };
            this.Hide();
            form3.Show();
        }
    }
    public partial class Form2 : Form
    {
        private readonly Form1 _form1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1)
            :this()
        {
            _form1 = form1;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form1.Show();
        }
    }
