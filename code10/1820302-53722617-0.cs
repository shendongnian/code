    var app = new Application();
    _Workbook workbook = app.Workbooks.Add(Type.Missing);
    app.Visible = true;
    _Worksheet worksheet = (Worksheet) workbook.Sheets["Sayfa1"];
    worksheet.Name = "Export";
    dataGridView1.Columns[0].Visible = false;
    List < DataGridViewColumn > listVisible = new List < DataGridViewColumn > ();
    foreach(DataGridViewColumn col in dataGridView1.Columns) {
        if (col.Visible)
            listVisible.Add(col);
    }
    for (int i = 0; i < listVisible.Count; i++) {
        worksheet.Cells[1, i + 1] = listVisible[i].HeaderText;
    }
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) {
        for (int j = 0; j < listVisible.Count; j++) {
            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[listVisible[j].Name].Value.ToString();
        }
    }
