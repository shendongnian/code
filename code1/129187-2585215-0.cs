    Dim Doc As New HtmlDocument()
    Doc.LoadXML(Markup)
    If Doc.ParseErrors.Count > 0 Then 
       Dim Node As HtmlNode  Doc.DocumentNode.SelectSingleNode("//body"); 
 
       If Node IsNot Nothing Then
            'Do something with Node 
       End If
    End If
