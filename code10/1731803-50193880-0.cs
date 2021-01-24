        public void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            for (int counter = 0; counter < richTextBox1.TextLength; counter++)
            {
                if (richTextBox1.Text[counter] == ' ')
                {
                    n++;
                }
            }
            MessageBox.Show(n.ToString("N1"));
        }
