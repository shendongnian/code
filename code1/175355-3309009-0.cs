    var dgvColumns = dataGridView.Columns.Cast<DataGridViewColumn>();
    var dsColumns = dataSet.Tables[0].Columns;
    
    // This will give you an IEnumerable<DataColumn>
    var dsDgvColumns = dgvColumns
        .Select(c => dsColumns[c.DataPropertyName]);
    
    // Then you can do this
    var columnsOnlyInDs = dsColumns.Cast<DataColumn>().Except(dsDgvColumn);
