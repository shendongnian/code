        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "easter bunny")
            {
                for(int i=0; i<10; i++)
                {
                    MessageBox.Show($"You entered easter bunny in the textbox! {i}");
                }
            }
        }
