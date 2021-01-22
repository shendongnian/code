    class MyForm : Form {
            List<string> values;
            BindingSource source;
    
            public MyForm()
            {
                InitializeComponent();
            }
    
            public MyForm(ref List<string> values):this()
            {
                if (values == null)
                    values = new List<string>();
    
                this.values = values;
    
                checkedListBox1.DisplayMember = "Value";
                checkedListBox1.ValueMember = "Value";
                source = new BindingSource(this.values, null);
                checkedListBox1.DataSource = source;
            }
    
            private void AddItemButton_Click(object sender, EventArgs e)
            {
                this.source.Add(textBox1.Text);
                textBox1.Text = string.Empty;
            }
    }
