    frm1.dataGridView1.Columns.Clear();
    frm1.dataGridView1.Rows.Clear();
    if (reader.HasRows)
    {
        DataTable schema = reader.GetSchemaTable();
        int field_num = 0;
        foreach (DataRow schema_row in schema.Rows)
        {
            int col_num = frm1.dataGridView1.Columns.Add(
                "col" + field_num.ToString(),
                schema_row.Field<string>("ColumnName"));
            field_num++;
            frm1.dataGridView1.Columns[col_num].AutoSizeMode = 
                DataGridViewAutoSizeColumnMode.AllCells;
        }
        object[] values = new object[reader.FieldCount];
        while (reader.Read())
        {
            reader.GetValues(values);
            frm1.dataGridView1.Rows.Add(values);
        }
    }
