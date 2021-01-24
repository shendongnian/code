    public Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateForm2();
        }
        public void CreateForm2()
        {
            Form2 form2 = new Form2();
            form2.FormClosing += form2_FormClosing;
        }
        public void form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This bit removes the event handler so clears up memory leaks
            Form2 form2 = sender as Form2;
            if (form2 != null)
            {
                form2.FormClosing -= form2_FormClosing;
            }
            // Do stuff here when form2 is closed
        }
    }
