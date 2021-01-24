    public static class HtmlHelpers
    {
    	public static string ToHtmlTable(this HashSet<dynamic> obj)
    	{
    		return ToHtmlTableConverter(obj);
    	}
    	
    	public static string ToHtmlTable(this ICollection obj) {
    		return ToHtmlTableConverter(obj);
    	}
    
    	public static string ToHtmlTable(this System.Data.DataTable obj)
    	{
    		return ConvertDataTableToHTML(obj);
    	}
    
    	private static string ToHtmlTableConverter( object obj  )  
    	{
    		var jsonStr = JsonConvert.SerializeObject(obj);
    		var data = JsonConvert.DeserializeObject<System.Data.DataTable>(jsonStr);
    		var html = ConvertDataTableToHTML(data);
    		return html;
    	}
    
    	private static string ConvertDataTableToHTML(System.Data.DataTable dt)
    	{
    		var html = new StringBuilder("<table>");
    		
    		//header
    		html.Append("<thead><tr>");
    		for (int i = 0; i < dt.Columns.Count; i++)
    			html.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
    		html.Append("</tr></thead>");
    		
    		//body
    		html.Append("<tbody>");
    		for (int i = 0; i < dt.Rows.Count; i++)
    		{
    			html.Append("<tr>");
    			for (int j = 0; j < dt.Columns.Count; j++)
    				html.Append("<td>" + dt.Rows[i][j].ToString() + "</td>");
    			html.Append( "</tr>");
    		}
    		
    		html.Append("</tbody>");
    		html.Append("</table>");
    		return html.ToString();
    	}
    }
