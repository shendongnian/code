        Public Form
    {
    InitializeComponent();  
    this.MouseWheel += new MouseEventHandler(Panel1_MouseWheel);
    }
    
     private void Panel1_MouseWheel(object sender, MouseEventArgs e)
            {
             panel1.Focus();
             }
