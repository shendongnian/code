    Public Shared Function DeserializeFromXML(Of T)(ByRef strFileNameAndPath As String) As T
        Dim deserializer As New System.Xml.Serialization.XmlSerializer(GetType(T))
        Dim srEncodingReader As IO.StreamReader = New IO.StreamReader(strFileNameAndPath, System.Text.Encoding.UTF8)
        Dim ThisFacility As T
    
        ThisFacility = DirectCast(deserializer.Deserialize(srEncodingReader), T)
        srEncodingReader.Close()
        srEncodingReader.Dispose()
    
        Return ThisFacility
    End Function
    
    
    Public Shared Function DeserializeFromXML1(Of T)(ByRef strFileNameAndPath As String) As System.Collections.Generic.List(Of T)
        Dim deserializer As New System.Xml.Serialization.XmlSerializer(GetType(System.Collections.Generic.List(Of T)))
        Dim srEncodingReader As IO.StreamReader = New IO.StreamReader(strFileNameAndPath, System.Text.Encoding.UTF8)
        Dim FacilityList As System.Collections.Generic.List(Of T)
        FacilityList = DirectCast(deserializer.Deserialize(srEncodingReader), System.Collections.Generic.List(Of T))
        srEncodingReader.Close()
        srEncodingReader.Dispose()
    
        Return FacilityList
    End Function
