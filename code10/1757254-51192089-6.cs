        public partial class Form1 : Form
        {            
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    var p = frm2.Person;
                }
            }
       }
        
       public partial class Form2 : Form
       {
            public person Person { get; set; }            
            private void button1_Click(object sender, EventArgs e)
            {
                this.Person = new Person();
                //set properties in Person object
            }
        }
