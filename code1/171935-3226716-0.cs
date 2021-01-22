        private void button1_Click(object sender, EventArgs e)
        {
            List<double> doubleList = new List<double>();
            foreach (TextBox t in panel1.Controls)
                doubleList.Add(this.checkTextBox(t));
        }
        private double checkTextBox(TextBox t)
        {
            return (t.Text != string.Empty) ? Double.Parse(t.Text.Trim()) : 0;
        }
