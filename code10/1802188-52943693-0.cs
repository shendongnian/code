      public partial class Form2 : Form
        {
            public interface ABC
            {
                 void OK(string data);
            }
    
            public ABC abc { get; set; } 
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                abc.OK("hi");
            }
        }
