    public partial class MyForm: Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        private Form2 f2;
        private void Button1_Click (object sender, EventArgs e)
        (    
            if (null == f2 || f2.IsDisposed)
                f2 = new Form2();
            f2.Show ();
        )
    }
