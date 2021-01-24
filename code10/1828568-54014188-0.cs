    static string ConvertDataTableToHTMLExtra(DataTable dt) 
    {
           StringBuilder html = new StringBuilder();
           html.Append("<table>");
    
           //add header row
           html.Append("<thead>");
           html.Append("<tr>");
                
           for (int i = 0; i < dt.Columns.Count; i++)
                html.Append("<td>").Append(dt.Columns[i].ColumnName).Append("</td>");
                
             html.Append("</tr>");
             html.Append("</thead>");
    
                //add rows
           for (int i = 0; i < dt.Rows.Count; i++)
           {
                 html.Append("<tr>");
                 for (int j = 0; j < dt.Columns.Count; j++)
                      html.Append("<td>").Append(dt.Rows[i][j]).Append("</td>");
                 html.Append("</tr>");
           }
    
           html.Append("</table>");
    
           return html.ToString();
    }
