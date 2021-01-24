        List<string> source = new List<string>();
        public Form1()
        {
            InitializeComponent();
            source.Add("Item 1");
            source.Add("Item 2");
            comboBox1.Items.AddRange(source.ToArray());
        }
        // Enter key detection as shown in https://stackoverflow.com/a/1226740/4034168
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!source.Contains(comboBox1.Text))
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.SelectedItem = null;
                }
            }
        }
        
