    public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
    
            }
    
       private void button1_Click(object sender, EventArgs e)
            {
    Form2 form2 = new Form2(this);
    form2.ShowDialog();
            }
    
    ///to set the visibility of things you want 
            public void SetVisibility(bool visibility)
            {
    button1.Visibility = visibility;
            }
        
        }
