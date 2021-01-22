    Private Sub NodeItterate(XDoc As XElement, XPath As String)
        'get the deepest path
        Dim nodes As IEnumerable(Of XElement)
        nodes = XDoc.XPathSelectElements(XPath)
        'if it doesn't exist, try the next shallow path
        If nodes.Count = 0 Then
            NodeItterate(XDoc, XPath.Substring(0, XPath.LastIndexOf("/")))
            'by this time all the required parent elements will have been constructed
            Dim ParentPath As String = XPath.Substring(0, XPath.LastIndexOf("/"))
            Dim ParentNode As XElement = XDoc.XPathSelectElement(ParentPath)
            Dim NewElementName As String = XPath.Substring(XPath.LastIndexOf("/") + 1, XPath.Length - XPath.LastIndexOf("/") - 1)
            ParentNode.Add(New XElement(NewElementName))
        End If
        'if we find there are more than 1 elements at the deepest path we have access to, we can't proceed
        If nodes.Count > 1 Then
            Throw New ArgumentOutOfRangeException("There are too many paths that match your expression.")
        End If
        'if there is just one element, we can proceed
        If nodes.Count = 1 Then
            'just proceed
        End If
    End Sub
    Public Sub CreateXPath(ByVal XDoc As XElement, ByVal XPath As String)
        If XPath.Contains("//") Or XPath.Contains("*") Or XPath.Contains(".") Then
            Throw New ArgumentException("Can't create a path based on searches, wildcards, or relative paths.")
        End If
        If Regex.IsMatch(XPath, "\[\]()@='<>\|") Then
            Throw New ArgumentException("Can't create a path based on predicates.")
        End If
        'we will process this recursively.
        NodeItterate(XDoc, XPath)
    End Sub
