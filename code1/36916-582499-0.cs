        public class SortableDataTable : DataTable 
        {
            public DataView ApplySort(Comparison<DataRow> comparison)
            {
    
                DataTable table = this.Clone();
                List<DataRow> rows = new List<DataRow>();
                foreach (DataRow row in this.Rows)
                {
                    rows.Add(row);    
                }
    
                rows.Sort(comparison);
    
                foreach (DataRow row in rows)
                {
                    table.Rows.Add(row.ItemArray);
                }
    
    
                return table.DefaultView;
            }
