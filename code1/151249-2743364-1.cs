    public partial class Form1 : Form
    {
        // Instance of DummyObject
        DummyObject dummyObject = new DummyObject();
        // Create Instance of Form2
        Form2 frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();            
            // Assign DummyObject to Form2.DummyObject property
            frm2.DummyObject = this.dummyObject;
            // Change Form2 DummyObject.Name
            frm2.DummyObject.Name = "I am changed for Form2.";
            // Display Form2
            frm2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dummyObject.Name);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Change Name of Form1 DummyObject
            this.dummyObject.Name = "I am changed from Form1.";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Assign new Instance
            this.dummyObject = new DummyObject();
            // Change Name value
            this.dummyObject.Name = "I am rechanged from Form1.";
            
            // Reassign Form2.DummyObject the newly created instance
            // for synchronization purposes
            this.frm2.DummyObject = this.dummyObject;         
        }       
    }
