    Imports System.Xml
    Imports System.IO
    Imports System.Net
    Imports System.Text
    Function FromHtml(ByVal reader As TextReader) As XmlDocument
        '' setup SgmlReader   
        Dim sgmlReader As Sgml.SgmlReader = New Sgml.SgmlReader()
        sgmlReader.DocType = "HTML"
        sgmlReader.WhitespaceHandling = WhitespaceHandling.None
        sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower
        sgmlReader.InputStream = reader
        '' create document 
        Dim doc As XmlDocument = New XmlDocument()
        doc.PreserveWhitespace = True
        doc.XmlResolver = Nothing
        doc.Load(sgmlReader)
        Return doc
    End Function
    Function LoadWebText(ByVal URL As String) As String
        Dim objWebClient As New WebClient()
        Dim objUTF8 As New UTF8Encoding()
        Dim xml As New XmlDocument
        xml = FromHtml(New StringReader(objUTF8.GetString(objWebClient.DownloadData(URL))))
        
        Return xml.InnerText()
    End Function
