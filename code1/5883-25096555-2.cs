    ''' <summary>
    ''' Determines whether a Type can be serialized.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <returns><c>true</c> if Type can be serialized; otherwise, <c>false</c>.</returns>
    Private Function IsTypeSerializable(Of T)() As Boolean
        Return Attribute.IsDefined(GetType(T), GetType(SerializableAttribute))
    End Function
    ''' <summary>
    ''' Determines whether a Type can be serialized.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="Type">The Type.</param>
    ''' <returns><c>true</c> if Type can be serialized; otherwise, <c>false</c>.</returns>
    Private Function IsTypeSerializable(Of T)(ByVal Type As T) As Boolean
        Return Attribute.IsDefined(GetType(T), GetType(SerializableAttribute))
    End Function
