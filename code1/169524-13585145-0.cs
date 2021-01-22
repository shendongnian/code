        Form1 anaform = new Form1();
        Utils Utility = new Utils();
        public Yekiler()
        {
            InitializeComponent();
        }
        public void Yekiler_Load(object sender, EventArgs e)
        {
            anaform = Application.OpenForms["Form1"] as Form1;
            
            
            foreach (DataColumn kolon in anaform.OGRENCILER.Columns)	            { this.comboBox1.Items.Add(kolon.ToString());}
        }
       
    }
