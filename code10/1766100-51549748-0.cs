            if (textBox1.Text == "")
            {
                MessageBox.Show("Field [Email] can not be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckNullValues())
            {
                MessageBox.Show("Insert record");
            }       
        }
