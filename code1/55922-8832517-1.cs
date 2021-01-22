    private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
             
            CheckBox headerBox = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]);
            int index = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = headerBox.Checked;
            }
