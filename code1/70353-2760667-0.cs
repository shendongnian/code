        /// <summary>
        /// Dumps the passed DataSet obj for debugging as list of html tables
        /// </summary>
        /// <param name="msg"> the msg attached </param>
        /// <param name="ds"> the DataSet object passed for Dumping </param>
        /// <returns> the nice looking dump of the DataSet obj in html format</returns>
        public static string DumpHtmlDs(string msg, ref System.Data.DataSet ds)
        {
            StringBuilder objStringBuilder = new StringBuilder();
            objStringBuilder.AppendLine("<html><body>");
            if (ds == null)
            {
                objStringBuilder.AppendLine("Null dataset passed ");
                objStringBuilder.AppendLine("</html></body>");
                WriteIf(objStringBuilder.ToString());
                return objStringBuilder.ToString();
            }
            objStringBuilder.AppendLine("<p>" + msg + " START </p>");
            if (ds != null)
            {
                if (ds.Tables == null)
                {
                    objStringBuilder.AppendLine("ds.Tables == null ");
                    return objStringBuilder.ToString();
                }
                
                foreach (System.Data.DataTable dt in ds.Tables)
                {
                    
                    if (dt == null)
                    {
                        objStringBuilder.AppendLine("ds.Tables == null ");
                        continue;
                    }
                    objStringBuilder.AppendLine("<table>");
                    //objStringBuilder.AppendLine("================= My TableName is  " +
                    //dt.TableName + " ========================= START");
                    int colNumberInRow = 0;
                    objStringBuilder.Append("<tr><th>row number</th>");
                    foreach (System.Data.DataColumn dc in dt.Columns)
                    {
                        if (dc == null)
                        {
                            objStringBuilder.AppendLine("DataColumn is null ");
                            continue;
                        }
                        
                        objStringBuilder.Append(" <th> |" + colNumberInRow.ToString() + " | ");
                        objStringBuilder.Append(  dc.ColumnName.ToString() + " </th> ");
                        colNumberInRow++;
                    } //eof foreach (DataColumn dc in dt.Columns)
                    objStringBuilder.Append("</tr>");
                    int rowNum = 0;
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        objStringBuilder.Append("<tr><td> row - | " + rowNum.ToString() + " | </td>");
                        int colNumber = 0;
                        foreach (System.Data.DataColumn dc in dt.Columns)
                        {
                            objStringBuilder.Append(" <td> |" + colNumber + "|" );
                            objStringBuilder.Append(dr[dc].ToString() + "  </td>");
                            colNumber++;
                        } //eof foreach (DataColumn dc in dt.Columns)
                        rowNum++;
                        objStringBuilder.AppendLine(" </tr>");
                    }	//eof foreach (DataRow dr in dt.Rows)
                    
                    objStringBuilder.AppendLine("</table>");
                    objStringBuilder.AppendLine("<p>" + msg + " END </p>");
                }	//eof foreach (DataTable dt in ds.Tables)
            } //eof if ds !=null 
            else
            {
                objStringBuilder.AppendLine("NULL DataSet object passed for debugging !!!");
            }
            return objStringBuilder.ToString();
        } 
