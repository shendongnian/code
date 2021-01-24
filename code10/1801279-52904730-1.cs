    private void button1_Click(object sender, EventArgs e)
            {
                int acorns = int.Parse(textBox1.Text);
                if (acorns >= 40 && (System.DateTime.Today.DayOfWeek == DayOfWeek.Saturday || System.DateTime.Today.DayOfWeek == DayOfWeek.Sunday || acorns  <= 60))
                {
    
                    MessageBox.Show("Good Party");
                }
                else
                {
                    MessageBox.Show("Terrible Party");
                }
            }
