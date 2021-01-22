    [System.Runtime.CompilerServices.Extension()]
    public string ToHtmlTable<T>(IEnumerable<T> list, string propertiesToIncludeAsColumns = "")
    {
    	return ToHtmlTable(list, string.Empty, string.Empty, string.Empty, string.Empty, propertiesToIncludeAsColumns);
    }
    
    [System.Runtime.CompilerServices.Extension()]
    public string ToHtmlTable<T>(IEnumerable<T> list, string tableSyle, string headerStyle, string rowStyle, string alternateRowStyle, string propertiesToIncludeAsColumns = "")
    {
    	dynamic result = new StringBuilder();
    	if (String.IsNullOrEmpty(tableSyle)) {
    		result.Append("<table id=\"" + typeof(T).Name + "Table\">");
    	} else {
    		result.Append((Convert.ToString("<table id=\"" + typeof(T).Name + "Table\" class=\"") + tableSyle) + "\">");
    	}
    
    	dynamic propertyArray = typeof(T).GetProperties();
    
    	foreach (object prop in propertyArray) {
    		if (String.IsNullOrEmpty(headerStyle)) {
    			result.AppendFormat("<th>{0}</th>", prop.Name);
    		} else {
    			result.AppendFormat("<th class=\"{0}\">{1}</th>", headerStyle, prop.Name);
    		}
    	}
    
    	for (int i = 0; i <= list.Count() - 1; i++) {
    		if (!String.IsNullOrEmpty(rowStyle) && !String.IsNullOrEmpty(alternateRowStyle)) {
    			result.AppendFormat("<tr class=\"{0}\">", i % 2 == 0 ? rowStyle : alternateRowStyle);
    
    		} else {
    			result.AppendFormat("<tr>");
    		}
    		foreach (object prop in propertyArray) {
    			if (string.IsNullOrEmpty(propertiesToIncludeAsColumns) || propertiesToIncludeAsColumns.Contains(prop.Name + ",")) {
    				object value = prop.GetValue(list.ElementAt(i), null);
    				result.AppendFormat("<td>{0}</td>", value ?? String.Empty);
    			}
    		}
    		result.AppendLine("</tr>");
    	}
    
    	result.Append("</table>");
    
    	return result.ToString();
    }
