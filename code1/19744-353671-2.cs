    public String ExportDataGrid(DataGrid grid)
    {
        string colPath;
        System.Reflection.PropertyInfo propInfo;
        System.Windows.Data.Binding binding;
        System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
        System.Collections.IList source = (grid.DataContext as System.Collections.IList);
        if (source == null)
            return "";
        
        foreach (Object data in source)
        {
            foreach (DataGridColumn col in datagrid.Columns)
            {
                if (col is DataGridBoundColumn)
                {
                    binding = (col as DataGridBoundColumn).Binding;
                    colPath = binding.Path.Path;
                    propInfo = data.GetType().GetProperty(colPath);
                    if (propInfo != null)
                    {
                        strBuilder.Append(propInfo.GetValue(data, null).ToString());
                        strBuilder.Append(",");
                    }                        
                }
            }
            strBuilder.Append("\r\n");
        }
    
    
        return strBuilder.ToString();
    }
