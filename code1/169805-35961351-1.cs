    IEnumerable<DataGridViewRow> sel = null;
    dataGridView1.BeforeCellMouseDown = 
        e => {
            if (yourCondition)
                // Save the selection
                sel = dataGridView1.SelectedRows.OfType<DataGridViewRow>();
            else
                sel = null;
        };
    dataGridView1.AfterCellMouseDown = 
        e => {
            if(sel != null) {
                // Restore the selection
                foreach(var row in sel)
                    row.Selected = true;
            }
        };
