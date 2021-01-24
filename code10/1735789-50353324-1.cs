    public partial class Form1 : Form
    {
        private List<TestModel> _dataList = new List<TestModel>();
        private BindingSource _binding = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            _binding.DataSource = _dataList;
            dataGridView1.DataSource = _binding;
        }
        private int _counter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                _counter++;
                _dataList.Add(new TestModel()
                {
                    ID = _counter,
                    Name = "Name " + _counter
                });
            }
            _binding.ResetBindings(false);
        }
        private class TestModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
