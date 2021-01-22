    private void exportHistoryButton_Click(object sender, RoutedEventArgs e) 
    {
        string data = ExportDataGrid(true, historyDataGrid);
        SaveFileDialog sfd = new SaveFileDialog()
        {
    	DefaultExt = "csv",
    	Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*",
    	FilterIndex = 1
        };
        if (sfd.ShowDialog() == true)
        {
    	using (Stream stream = sfd.OpenFile())
    	{
    	    using (StreamWriter writer = new StreamWriter(stream)) {
    		writer.Write(data);
    		writer.Close();
    	    }
    	    stream.Close();
    	}
        }
    }
    
    private string FormatCSVField(string data) {
        return String.Format("\"{0}\"",
    		data.Replace("\"", "\"\"\"")
    		.Replace("\n", "")
    		.Replace("\r", "")
    	    );
    }
    
    public string ExportDataGrid(bool withHeaders, DataGrid grid)
    {
        string colPath;
        System.Reflection.PropertyInfo propInfo;
        System.Windows.Data.Binding binding;
        System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
        System.Collections.IList source = (grid.ItemsSource as System.Collections.IList);
        if (source == null)
    	return "";
    
        List<string> headers = new List<string>();
        grid.Columns.ToList().ForEach(col => {
    	if (col is DataGridBoundColumn){
    	    headers.Add(FormatCSVField(col.Header.ToString()));
    	}
        });
        strBuilder
    	.Append(String.Join(",", headers.ToArray()))
    	.Append("\r\n");
    
        foreach (Object data in source)
        {
    	List<string> csvRow = new List<string>();
    	foreach (DataGridColumn col in grid.Columns)
    	{
    	    if (col is DataGridBoundColumn)
    	    {
    		binding = (col as DataGridBoundColumn).Binding;
    		colPath = binding.Path.Path;
    		propInfo = data.GetType().GetProperty(colPath);
    		if (propInfo != null)
    		{
    		    csvRow.Add(FormatCSVField(propInfo.GetValue(data, null).ToString()));
    		}
    	    }
    	}
    	strBuilder
    	    .Append(String.Join(",", csvRow.ToArray()))
    	    .Append("\r\n");
        }
    
    
        return strBuilder.ToString();
    }
