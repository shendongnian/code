    public partial class Second : Form
    {
        public Second()
        {
            InitializeComponent();
        }
        internal Main Main { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Main != null)
            {
                this.Main.Button1.PerformClick();
            }
        }
    }
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Second run_second_form = new Second();
            run_second_form.Main = this;
            run_second_form.Show();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked on Main");
        }
    }
