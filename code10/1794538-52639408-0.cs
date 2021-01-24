        private void button5_Click(object sender, EventArgs e)
        {
            string searchValue = textBox5.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                decimal earnedTotal = 0;
                int matches = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(!row.IsNewRow)
                    {
                        if((string)row.Cells[1].Value == searchValue)
                        {
                            row.Selected = true;
                            decimal earned;
                            if (decimal.TryParse((string)row.Cells[2].Value, out earned))
                                earnedTotal += earned;
                            matches++;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }
                if(matches == 0)
                    MessageBox.Show("Record is not avalable for this Name: " + textBox5.Text, "Not Found");
                textBox6.Text = matches.ToString();
                txtEarnedTotal.Text = earnedTotal.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
