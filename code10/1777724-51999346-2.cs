    StringBuilder sb = new StringBuilder();
    //Open table
    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
    //Open first tr for all of th
    sb.Append("<tr>");
    foreach (DataColumn column in dt.Columns)
    {
         sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
         sb.Append(column.ColumnName);
         sb.Append("</th>");
    }
    //Close first tr for all of th
    sb.Append("</tr>");
    foreach (DataRow row in dt.Rows)
    {   
        //Open tr for all of rows
        sb.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            sb.Append("<td>");
            sb.Append(row[column]);
            sb.Append("</td>");
        }
        //Close tr for all of rows
        sb.Append("</tr>");
    }
    //Close table
    sb.Append("</table>");     
            
