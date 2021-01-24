    public partial class Form2 : Form
    {
            public Form2()
            {
                InitializeComponent();
            }
    
            //Added a button to Form2.cs
            //Set a button click event
            private void button1_Click(object sender, EventArgs e)
            {
                 other_class obj = new other_class();    
                 obj.a_function();      
            }
    }
