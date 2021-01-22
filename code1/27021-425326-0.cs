    private object oldItem = new object();
    
            private void button3_Click(object sender, EventArgs e)
            {
                DateTime date = DateTime.Now;
                for (int i = 1; i <= 10; i++)
                {
                    this.comboBox1.Items.Add(date.AddDays(i));
                }
    
                oldItem = this.comboBox1.SelectedItem;
            }
    
            private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                //do what you need with the oldItem variable
                if (oldItem != null)
                {
                    MessageBox.Show(oldItem.ToString());
                }
    
                this.oldItem = this.comboBox1.SelectedItem;
            }
