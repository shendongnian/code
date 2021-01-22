        // There is only one table in my case
        var deviceTable = from table in document.DocumentNode.SelectNodes(XPathQueries.SELECT_TABLE)
                               from row in table.SelectNodes(HtmlBody.TR)
           	                   from header in row.SelectNodes(HtmlBody.T_HEADER)
	                           from data in row.SelectNodes(HtmlBody.T_DATA)
                               select new {Header = header.InnerText, Data = data.InnerText};
        foreach (var row in deviceTable)
        {
 	        Debug.WriteLine(row.Header.AppendText(@" = " + row.Data));
        }
  
