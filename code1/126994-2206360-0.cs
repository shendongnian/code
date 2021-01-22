        private void Form1_Load(object sender, EventArgs e)
        {
            List<MyDummyObject> data = new List<MyDummyObject>() 
                { 
                     new MyDummyObject() {ID = 1, RandomBoolValue = true, SomeRandomDescription = "First item" } 
                    ,new MyDummyObject() {ID=2, RandomBoolValue = false, SomeRandomDescription = "Second item" }
                };
            comboBox1.DisplayMember = "SomeRandomDescription";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = data;
        }
        private class MyDummyObject
        {
            public int ID { get; set; }
            public string SomeRandomDescription { get; set; }
            public bool RandomBoolValue { get; set; }
            public override string ToString()
            {
                return "zzzzzz";
            }
        }
