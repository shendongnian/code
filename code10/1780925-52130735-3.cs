    int index = this.ArrayList.BinarySearch(textBoxBinarySearch.Text);
    if (index > -1)
    {
        dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        dataGridView2.Rows[index].Selected = true;
        dataGridView2.CurrentCell = dataGridView2.Rows[index].Cells[0];
        MessageBox.Show("Index is equal to: " + index, "Binary Search");
    }
