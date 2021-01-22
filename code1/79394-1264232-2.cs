    private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource=AutoCompleteSource.CustomSource;
                string[] ar = (string[])(listBox1.Items.Cast<string>()).ToArray<string>();
                textBox1.AutoCompleteCustomSource.AddRange(ar);
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                listBox1.Text  = textBox1.Text;
            }
