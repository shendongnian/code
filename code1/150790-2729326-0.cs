    private class Data
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public Form1()
    {
        InitializeComponent();
        comboBox1.Items.Add(new Data{Name = "Test", Value = "Hello"});
        comboBox1.Items.Add(new Data {Name = "Test2", Value = "World"});
        comboBox1.DisplayMember = "Name";
        comboBox1.ValueMember = "Value";
    }
