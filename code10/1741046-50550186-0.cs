    System.Text.StringBuilder sb = new System.Text.StringBuilder;
    if(InData.Rows.Count > 0)
    {
    sb.Append("Hi There,<br><br>");
    sb.Append("Please find the below mentioned Information. <br><br>");
    sb.Append("<table style='border:1px solid black; border-collapse: collapse;'>");
    sb.Append("<tr style='border:1px solid black; border-collapse: collapse; padding:2px;'>");
    foreach (System.Data.DataColumn dc in InData.Columns)
    {
       sb.Append("<th style='border:1px solid black; border-collapse: collapse; padding:2px;'>");
       sb.Append(dc.ColumnName);
       sb.Append("</th>");
    }
    sb.Append("</tr>");
    
    int rowNumber = 1;
    foreach (System.Data.DataRow dr in InData.Rows)
    {
        
       sb.Append("<tr style='border:1px solid black; border-collapse: collapse; padding:2px;'>");
        
    int colNumber=1;
      foreach (System.Data.DataColumn dc in InData.Columns)
       {
    if(colNumber==1)
    {
              sb.Append("<td style='border:1px solid black; border-collapse: collapse; padding:2px;background-color:yellow;'>");
    }
    else
    {
              sb.Append("<td style='border:1px solid black; border-collapse: collapse; padding:2px;'>");
    
    }
              sb.Append("<td style='border:1px solid black; border-collapse: collapse; padding:2px;'>");
              sb.Append(dr[dc.ColumnName].ToString());
              sb.Append("</td>");
    colNumber++;
           }
           sb.Append("</tr>");
           rowNumber ++;
        }
        sb.Append("</table><br><br>");
        sb.Append("Regards,<br>");
        sb.Append("Team QueryBot");
        }
        outEmailHtmlTable = sb.ToString();
