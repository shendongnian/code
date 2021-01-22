    Dim Val As String = "&lt;foo&gt;&lt;bar&gt;test&lt;/bar&gt;&lt;/foo&gt;"
    Dim Xml As String = HttpUtility.HtmlDecode(Val)
    Dim Doc As New XmlDocument()
    Doc.LoadXml(Xml)
    Dim Writer As New StringWriter()
    Doc.Save(Writer)
    Console.Write(Writer.ToString())
