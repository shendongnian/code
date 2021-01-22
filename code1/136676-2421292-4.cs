    public Form1()
        {
            InitializeComponent();
            //add values to combobox from some datasource
            comboBox1.Items.Add("Col1");
            comboBox1.Items.Add("Col2");
            comboBox1.Items.Add("Col3");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string updateStatement = String.Format("UPDATE Customer SET {0} = 'some value' WHERE {0} = 'some other value'", comboBox1.SelectedItem);
            //execute the updatestatement;
        }
