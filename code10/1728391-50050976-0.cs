    private void richTextBox2_KeyDown_Handler(object sender, KeyEventArgs e){
        if(e.KeyValue == 13 && dataGridView1.CurrentCell.RowIndex != -1 && richTextBox2.Text.ToString().Trim() != dataGridView1.CurrentCell.Value.ToString().Trim()){
            int    col    = dataGridView1.CurrentCell.ColumnIndex;
            int    row    = dataGridView1.CurrentCell.RowIndex;
            string ID     = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string table  = tabControl1.TabPages[(tabControl1.SelectedIndex)].Text;
            string column = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
            string value  = richTextBox2.Text.ToString().Trim();
            string query  = @"UPDATE [" + globalDatabase + @"].[dbo].[" + table + @"] SET [" + column + @"] = '" + value + @"' WHERE [ID] = '" + ID + @"'";
            WriteSQL(query);
            RefreshDGV1();
            dataGridView1.CurrentCell = this.dataGridView1[col, row];
            e.Handled = true; // STOP THE HANDLING
        }
    }
