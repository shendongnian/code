    public partial class Form2 : Form
        {
            bool formComplete = false;
    
            public Form2()
            {
                InitializeComponent();
               
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
               
                
                formComplete = true;
                tabControl1.SelectTab(1);
               
            }
    
            private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {
    
                    tabControl1.Enabled = false;
    
                    if (formComplete)
                    {
                        MessageBox.Show("You will be taken to next tab");
                        tabControl1.SelectTab(1);
    
                    }
                    else
                    {
                        MessageBox.Show("Try completing form first");
                        tabControl1.SelectTab(0);
                    }
                    tabControl1.Enabled = true;
                }
            }
        }
