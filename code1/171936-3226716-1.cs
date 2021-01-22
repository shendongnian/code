        private void button1_Click(object sender, EventArgs e)
        {
            List<double> doubleList = new List<double>();
            foreach (Control t in panel1.Controls)
                if(t is TextBox)
                    doubleList.Add(this.checkTextBox((TextBox)t));
        }
        private double checkTextBox(TextBox t)
        {
            return (t.Text != string.Empty) ? Double.Parse(t.Text.Trim()) : 0;
        }
