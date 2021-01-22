         private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = dataGridView1.CurrentCell.RowIndex.ToString();
            if (Convert.ToInt32(s) == 0)
            {
                Form f = new Form();
                ActivateMdiChild(f);
                f.Show();
            }
            if (Convert.ToInt32(s) == 1)
            {
                MessageBox.Show("Hi");
            }
        }
