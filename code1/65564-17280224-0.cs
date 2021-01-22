    // autosize all columns according to their content
    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
    // make column 1 (or whatever) fill the empty space
    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    // remove column 1 autosizing to prevent 'jumping' behaviour
    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
    // let the last column fill the empty space when the grid or any column is resized (more natural/expected behaviour) 
    dgv.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
