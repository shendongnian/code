       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
    /* any aditional verifications, can be added, then remove from the index selected */
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
