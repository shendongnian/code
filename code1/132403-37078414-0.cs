        private void dgUser_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView1.Rows.Count > MaxRowCount)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }
