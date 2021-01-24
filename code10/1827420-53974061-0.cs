        int nCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(textBox1.Text.Split(','));
            label2.Text = listBox1.Items.Count.ToString();
            nCount++;
        }
