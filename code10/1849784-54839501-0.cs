     public Form3()
     {
         InitializeComponent();
         button1.Enabled = false;
     }
     private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (listBox1.SelectedIndex != -1)
         {
             button1.Enabled = true;
         }
     }
