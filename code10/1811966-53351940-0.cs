    class Form2 : Form
    {
        public Form2()
        {
             InitializeComponent();
        }
        public AirlineCoordinator {get; set;}
        ...
    }
    class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent();
        }
        public AirlineCoordinator {get; set;}
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AirlineCoordinator = new AirlineCoordinator(...);
           ...
        }
        ...
        private void ShowForm2Button_Click(object sender, EventArgs e)
        {
            using(var form2 = new Form2())
            {
                form2.AirlineCoordinator = this.AirlineCoordinator;
                form2.ShowDialog(this);
            }
        }
    }
