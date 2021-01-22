    public partial class MyForm: Form
        {
            public MyForm()
            {
                InitializeComponent();
            }
        
            Form2 f2 = null;
            private void Button1_Click (object sender, EventArgs e)
            (    
                if(f2 == null)
                  f2 = new Form2();
                if(!f2.Visible)
                  f2.Show ();
            )
        }
