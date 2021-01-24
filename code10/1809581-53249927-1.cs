    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtName.Text = row.Cells["Name"].Value.ToString();
            var age = row.Cells["Age"].Value.ToString();
            ddlAgeList.Items.Insert(0,new ListItem(age));// 0 is index of item 
        }
    }
