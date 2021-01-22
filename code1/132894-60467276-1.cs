`
  ''' <summary>
  ''' Exports the object data to an XML formatted string.
  ''' Maintains CR characters after deserialization.
  ''' The object must be serializable to work.
  ''' </summary>
  Public Function ExportObjectXml(ByVal obj As Object) As String
    If obj Is Nothing Then
      Return String.Empty
    End If
    Dim serializer As New XmlSerializer(obj.GetType)
    Dim settings As New XmlWriterSettings With {.NewLineHandling = NewLineHandling.Entitize}
    Using output As New StringWriter
      Using writer As XmlWriter = XmlWriter.Create(output, settings)
        serializer.Serialize(writer, obj)
        Return output.ToString
      End Using
    End Using
  End Function
`
