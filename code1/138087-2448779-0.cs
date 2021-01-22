    private void BuildErrorNodes()
    {
        const string nodeFormat = @"<ERROR TYPE=""MISSED""><DATETIME>{0}</DATETIME><DETAIL>No information was read for expected sequence number {1}</DETAIL><PAGEID>{1}</PAGEID></ERROR>";
    
        var sb = new StringBuilder("<ERRORS>");
        foreach (var item in MyInfoCollection)
        {
            if (item.Value == null) 
            {
                sb.AppendFormat(
                    nodeFormat,
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"),
                    item.Key + 1
                );
            }
        }
    
        sb.Append("</ERRORS>");
    
        var errorsNode = MyXDocument.Descendants("ERRORS").FirstOrDefault();
        errorsNode.ReplaceWith(XElement.Parse(sb.ToString()));
    }
