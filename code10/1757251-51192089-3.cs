        private void button1_Form1_Click(object sender, EventArgs e)
                    {
                        var p = new Person();
                        Form2 frm2 = new Form2(p);
                        if(frm2.ShowDialog() == DialogResult.OK)
                        {
                            var updatedPerson = frm2.Person;
                        }
                    }
                }
        
        public partial class Form2 : Form
                {
                    public person Person {get;set;} 
                    public Form2(Person p)
                    {
                        this.Person = p;
                        InitializeComponent();
                    }
                 }
    
     private void button1_Form2_Click(object sender, EventArgs e)
            {
                //set properties of this.Person
            }
                
