      namespace Program_Pajak
        {
            public partial class formppn : Form
            {
        
               Stack sit = new Stack();
               Stack sht = new Stack();
    
                public formppn()
                {
                    InitializeComponent();
                }
        
                private void label2_Click(object sender, EventArgs e)
                {
        
                }
        
                private void formppn_Load(object sender, EventArgs e)//kinda confused, placing stack in which function
                {
        
                    int count1 = sit.Count;
                    int count2 = sht.Count;
                }
        
                private void button1_Click(object sender, EventArgs e) //this is proceed button for Push stack
                {
                    sit.Push(item);
                    si.Text = count1.ToString();
                }
        
                private void si_Click(object sender, EventArgs e)
                {
        
                }
            }
        }
