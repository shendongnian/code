      public Form1 _form1 { get; set; }
            public Form2(Form1 form1)
            {
                _form1 = form1;
                InitializeComponent();
            }
    
        public void button1_Click(object sender, EventArgs e)
            {
                _form1.label2.ForeColor = Color.Red;
            }
        }
