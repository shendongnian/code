    for (int i = 0; i < dataGridView3.Rows.Count; i++){
        for (int j = 0; j < dataGridView3.Columns.Count; j++){
            string formatValue = dataGridView3.Rows[i].Cells[j].Value.ToString();
    
            if( dataGridView3.Columns[j].HeaderText == "statusdate" || dataGridView3.Columns[j].HeaderText == "fplacementdate" || dataGridView3.Columns[j].HeaderText == "periodcomplertion"){
               formatValue.convertDateFormat();
            }
    
            worksheet.Cells[i + 2, j + 1] = formatValue;
        }
    }
