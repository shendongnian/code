    List<int> indexes = dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(x => Select(x => x.Index).ToList();
    int sum = 0;
    for (int i = 0; i < indexes.Count; i++)
    {
        // here the label text will be the last row price because you overwrite each time
        label3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        sum += int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
    }
    MessageBox.Show("Sum of selected rows = " + sum.ToString());
