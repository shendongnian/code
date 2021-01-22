        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.TextChanged+=new EventHandler(textBox1_TextChanged);
            col1.AddRange(new string[] { "avi avi", "avram avram" });
            col2.AddRange(new string[] { "boria boria", "boris boris" });
            textBox1.AutoCompleteCustomSource = col1;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection col2 = new AutoCompleteStringCollection();
        object locker = new object();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lock (locker)
            {
                if (textBox1.Text.StartsWith("a") && textBox1.AutoCompleteCustomSource != col1)
                {
                    textBox1.AutoCompleteCustomSource = col1;
                }
                if (textBox1.Text.StartsWith("b") && textBox1.AutoCompleteCustomSource != col2)
                {
                    textBox1.AutoCompleteCustomSource = col2;
                }
            }
        }
