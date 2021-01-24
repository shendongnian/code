    class Form2 : Form
    {
        public Form2()
        {
             InitializeComponent();
        }
        public AirlineCoordinator Coordinator {get; set;}
        ...
    }
    class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent();
        }
        public AirlineCoordinator Coordinator {get; set;}
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Coordinator = new AirlineCoordinator(...);
           ...
        }
        ...
        private void ShowForm2Button_Click(object sender, EventArgs e)
        {
            using(var form2 = new Form2())
            {
                form2.Coordinator = this.Coordinator;
                form2.ShowDialog(this);
            }
        }
    }
