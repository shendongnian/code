    Dim settings = New XmlWriterSettings With {.Indent = True,
                                              .NamespaceHandling = NamespaceHandling.OmitDuplicates,
                                              .OmitXmlDeclaration = True}
    Dim s As New MemoryStream
    Using writer = XmlWriter.Create(s, settings)
        ...
    End Using
