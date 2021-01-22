        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Column1 is 
            Column1.DataPropertyName = "Value1";
            Column1.Items.AddRange(Enumerable.Range(1, 10).Select(i => i.ToString()).ToArray());
            Column2.DataPropertyName = "Value2";
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.DataSource = (from obj in Enumerable.Range(1, 20)
                                        select new Model() { Value1 = obj, Value2 = ("Value2 #" + obj.ToString()) }).ToList();
        }
        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Exception.ToString());
        }
    }
    class Model
    {
        protected Int32 _value1;
        public Int32 Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                // Here is your property change event
                MessageBox.Show(value.ToString());
                _value1 = value;
            }
        }
        public String Value2 { get; set; }
    }`
