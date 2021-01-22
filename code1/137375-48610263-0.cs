    Public Function XmlSerializeObject(ByVal obj As Object) As String
        Dim xmlStr As String = String.Empty
        Dim settings As New XmlWriterSettings()
        settings.Indent = False
        settings.OmitXmlDeclaration = True
        settings.NewLineChars = String.Empty
        settings.NewLineHandling = NewLineHandling.None
        Using stringWriter As New StringWriter()
            Using xmlWriter__1 As XmlWriter = XmlWriter.Create(stringWriter, settings)
                Dim serializer As New XmlSerializer(obj.[GetType]())
                serializer.Serialize(xmlWriter__1, obj)
                xmlStr = stringWriter.ToString()
                xmlWriter__1.Close()
            End Using
            stringWriter.Close()
        End Using
        Return xmlStr.ToString
    End Function
    Public Function XmlDeserializeObject(ByVal data As [String], ByVal objType As Type) As Object
        Dim xmlSer As New System.Xml.Serialization.XmlSerializer(objType)
        Dim reader As TextReader = New StringReader(data)
        Dim obj As New Object
        obj = DirectCast(xmlSer.Deserialize(reader), Object)
        Return obj
    End Function
    
    
