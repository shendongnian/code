    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int SelectedId { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = SelectedId.ToString();
        }
    }
