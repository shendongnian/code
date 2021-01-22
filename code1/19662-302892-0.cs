    Public Shared Function SerializeToByteArray(ByVal object2Serialize As Object) As Byte()
        Using stream As New MemoryStream
            Dim xmlSerializer As New XmlSerializer(object2Serialize.GetType())
            xmlSerializer.Serialize(stream, object2Serialize)
            Return stream.ToArray()
        End Using
    End Function
    Public Shared Function SerializeToString(ByVal object2Serialize As Object) As String
        Dim bytes As Bytes() = SerializeToByteArray(object2Serialize)
        return Text.UTF8Encoding.GetString(bytes)
    End Function
