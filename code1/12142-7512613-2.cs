        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TotalRecall xx = new TotalRecall();
            Employee ee = new Employee();
            FileStream fs = File.Create("sss.xml");
            xx.Serialize(fs, ee, typeof(Employee));
            fs.Close();
            fs.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TotalRecall xx = new TotalRecall();
            FileStream fs=File.OpenRead("sss.xml");
            Employee ee = (Employee)xx.Deserialize(fs, typeof(Employee));
            fs.Close();
            fs.Dispose();
        }
    }
