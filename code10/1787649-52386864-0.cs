    // All the grids have the same structure
    // dataGridView1 columns: ID1, Name1
    // dataGridView2 columns: ID2, Name2
    // dataGridView3 columns: ID3, Name3
    // Get the unique identificators from dataGridView2
    var grid2IDs = (from r in dataGridView2.Rows.Cast<DataGridViewRow>() where r.Cells["ID2"].Value != null select (int)r.Cells["ID2"].Value).Distinct();
    // loop trough rows from dataGridView1 where ID is within grid2 unique IDs
    foreach (DataGridViewRow row in from r in dataGridView1.Rows.Cast<DataGridViewRow>() where r.Cells["ID1"].Value != null && grid2IDs.Contains((int)r.Cells["ID1"].Value) select r)
    {
        // Insert the row into dataGirdView3
        var newRow = dataGridView3.Rows[dataGridView3.Rows.Add()];
        for (var i = 0; i < row.Cells.Count; i++)
            newRow.Cells[i].Value = row.Cells[i].Value;
    };
