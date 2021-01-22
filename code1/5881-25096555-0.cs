    ''' <summary>
    ''' Determines whether an object can be serialized.
    ''' </summary>
    ''' <param name="Object">The object.</param>
    ''' <returns><c>true</c> if object is serializable; otherwise, <c>false</c>.</returns>
    Private Function IsObjectSerializable(ByVal [Object] As Object,
                                          Optional ByVal SerializationFormat As SerializationFormat =
                                                                                SerializationFormat.Xml) As Boolean
        Dim Serializer As Object
        Using fs As New MemoryStream
            Select Case SerializationFormat
                Case Data.SerializationFormat.Binary
                    Serializer = New BinaryFormatter()
                Case Data.SerializationFormat.Xml
                    Serializer = New Xml.Serialization.XmlSerializer([Object].GetType)
                Case Else
                    Throw New ArgumentException("Invalid SerializationFormat", SerializationFormat)
            End Select
            Try
                Serializer.Serialize(fs, [Object])
                Return True
            Catch ex As InvalidOperationException
                Return False
            End Try
        End Using ' fs As New MemoryStream
    End Function
