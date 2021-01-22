     public class MyTabItem : ObservableObject 
     {
    		private DataTable _dataTable = new DataTable();
            public DataTable dataTable
            {
                get { return _dataTable; }
            }
    
            private bool _toggleToRefresh = true;
            public bool toggleToRefresh
            {
                get { return _toggleToRefresh; }
                set
                {
                    if (_toggleToRefresh != value)
                    {
                        _toggleToRefresh = value;
                        RaisePropertyChanged("toggleToRefresh");
                    }
                }
            }
    
            public void addDTColumn()
            {
                toggleToRefresh = false;
                string newColumnName = "x" + dataTable.Columns.Count.ToString();
                dataTable.Columns.Add(newColumnName, typeof(double));
                foreach (DataRow row in dataTable.Rows)
                {
                    row[newColumnName] = 0.0;
                }
                toggleToRefresh = true;
            }
    
            public void addDTRow()
            {
                var row = dataTable.NewRow();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row[col.ColumnName] = 0.0;
                }
                dataTable.Rows.Add(row);
            }
     }
