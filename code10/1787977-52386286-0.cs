        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.Closed += F2_Closed;
        }
        private void F2_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Form2 was closed");
        }
