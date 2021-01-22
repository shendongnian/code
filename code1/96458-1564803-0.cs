    Public Shared Function Serialize(Of T)(ByVal value As T) As String
        If value Is Nothing Then
            Return Nothing
        End If
        Dim serializer As New XmlSerializer(GetType(T))
        Dim settings As New XmlWriterSettings
        settings.Encoding = New UnicodeEncoding(False, False) ' BOM not allowed in a .NET string
        settings.Indent = False
        settings.OmitXmlDeclaration = False
        Using textWriter As New StringWriter
            Using xmlWriter As XmlWriter = xmlWriter.Create(textWriter, settings)
                serializer.Serialize(xmlWriter, value)
            End Using
            Return textWriter.ToString()
        End Using
    End Function
    Public Shared Function Deserialize(Of T)(ByVal xml As String) As T
        If String.IsNullOrEmpty(xml) Then
            Return Nothing
        End If
        Dim serializer As New XmlSerializer(GetType(T))
        Dim settings As New XmlReaderSettings
        ' No settings need modifying here.
        Using textReader As New StringReader(xml)
            Using xmlReader As XmlReader = xmlReader.Create(textReader, settings)
                Return CType(serializer.Deserialize(xmlReader), T)
            End Using
        End Using
    End Function
