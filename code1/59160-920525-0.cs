    public static DataTable Union (DataTable First, DataTable Second)
    {
    
          //Result table
          DataTable table = new DataTable("Union");
    
          //Build new columns
          DataColumn[] newcolumns = new DataColumn[First.Columns.Count];
    
          for(int i=0; i < First.Columns.Count; i++)
          {
              newcolumns[i] = new DataColumn(
              First.Columns[i].ColumnName, First.Columns[i].DataType);
          }
    
          table.Columns.AddRange(newcolumns);
          table.BeginLoadData();
    
          foreach(DataRow row in First.Rows)
          {
               table.LoadDataRow(row.ItemArray,true);
          }
    
          foreach(DataRow row in Second.Rows)
          {
              table.LoadDataRow(row.ItemArray,true);
          }
    
          table.EndLoadData();
          return table;
    }
