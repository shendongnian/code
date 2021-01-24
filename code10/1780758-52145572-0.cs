    for (int row = 0; row < dataGridView1.Rows.Count; ++row) {
    bool isEmpty = false;
    for (int col = 0; col < dataGridView1.Columns.Count; ++col) {
        object value = dataGridView1.Rows[row].Cells[col].Value;
        if (value  == null || value  == DBNull.Value || String.IsNullOrWhitespace(value .ToString()) {
            isEmpty = true;
            break;
        }
    }
    if (isEmpty) {
        dataGridView1.Rows.RemoveAt(row--);
    }}
