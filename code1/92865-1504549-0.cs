    List<object> filteredData = new List<object>();
    foreach (object data in this.DataSource)
    {
        foreach (var column in this.Columns)
        {
            var value = data.GetType().GetProperty(column.Field).GetValue(data,null)
                                                                .ToString();
            if (value.Contains(this.ddFind.Text))
            {
                filteredData.Add(data);
                break;
            }
        }
     }
    
     this.ddGrid.DataSource = filteredData;
