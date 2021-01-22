    public partial class Form2 : Form
    {
        private DummyObject dummyObject;
        
        public Form2()
        {
            InitializeComponent();
        }
        public DummyObject DummyObject
        {
            get { return this.dummyObject; }
            set { this.dummyObject = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dummyObject.Name);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.dummyObject.Name = "I am changed from Form2.";            
        }
    }
