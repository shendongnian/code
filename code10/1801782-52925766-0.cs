    private void btnGet_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
            if (isSelected)
            {
                message += Environment.NewLine;
                message += row.Cells["Name"].Value.ToString();
            }
        }
     
        MessageBox.Show("Selected Values" + message);
    }
