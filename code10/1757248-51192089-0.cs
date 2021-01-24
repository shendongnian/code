    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
        
                Form2 frm2 = new Form2();
                if(frm2.ShowDialog() == DialogResult.OK)
                {
                    var p = frm2.Person;
                }
            }
        }
        
        class person
        {
            public string Name { get; set; }
            public int age { get; set; }
        }
        
        public partial class Form2 : Form
        {
            public person Person {get;set;} 
            public Form2()
            {
                InitializeComponent();
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                // How do I create a new instance of person using these variables
                this.Person = new Person();
                //set properties
            }
        }
