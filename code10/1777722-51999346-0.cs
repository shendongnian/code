    StringBuilder sb = new StringBuilder();
    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
    sb.Append("<tr>");
    foreach (DataColumn column in dt.Columns)
    {
         sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
         sb.Append(column.ColumnName);
         sb.Append("</th>");
    }
    sb.Append("</tr>");
    foreach (DataRow row in dt.Rows)
    {
        sb.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            sb.Append("<td>");
            sb.Append(row[column]);
            sb.Append("</td>");
        }
        sb.Append("</tr>");
    }
    sb.Append("</table>");     
            
