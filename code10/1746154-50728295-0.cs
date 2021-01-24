    public partial class Form1 : Form
    {
       Form1 form1; // form1 will store the reference of Form1
       public Form1()
       {
        form1 = this; // We initialize form1 in the constructor
        InitializeComponent();
       }
       // button to open form2
       private void button1_Click(object sender, EventArgs e)
       {
           Form2 form2 = new Form2(form1); // We open form2 with form1 as parameter
            form2.Visible = true;
        }
        public void openImage(int x, int y)
        {
        }
    }
