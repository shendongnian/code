    Dim sgmlReader As New Sgml.SgmlReader()
    Public htmldoc As New System.Xml.Linq.XDocument
    sgmlReader.DocType = "HTML"
    sgmlReader.WhitespaceHandling = System.Xml.WhitespaceHandling.All
    sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower
    sgmlReader.InputStream = New System.IO.StringReader(vSource)
    sgmlReader.CaseFolding = CaseFolding.ToLower
    htmldoc = XDocument.Load(sgmlReader)    
    Dim XNS As XNamespace 
    ' In this part you can have a bug, sometimes it cant get the Default Namespace*********
    Try
          XNS = htmldoc.Root.GetDefaultNamespace
    Catch
            XNS = "http://www.w3.org/1999/xhtml"
    End Try
    If XNS.NamespaceName.Trim = "" Then
            XNS = "http://www.w3.org/1999/xhtml"
    End If
    'use it with the linq commands
    For Each link In htmldoc.Descendants(XNS + "script")
            Scripts &= link.Value
    Next
