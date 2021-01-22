            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Error")
            {
                if (e.Value != null && e.Value.ToString() == "1")
                {
                     dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
