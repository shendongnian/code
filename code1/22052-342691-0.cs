    List<DataGridViewColumn> columns = new List<DataGridViewColumn>(dataGridView1.Columns);
    columns.Sort( delegate(DataGridViewColumn a, DataGridViewColumn b) {
                   return String.Compare( a.HeaderText, b.HeaderText ); }
    int n = 0;
    foreach( DataGridViewColumn col in columns )
       col.DisplayIndex = n++;
