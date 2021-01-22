    Public Function ExceptionToByteArray(obj As Object) As Byte()
    	If obj Is Nothing Then Return Nothing
    	Using ms As New MemoryStream
    		Dim dcs As New DataContractSerializer(GetType(Exception))
    		dcs.WriteObject(ms, obj)
    		Return ms.ToArray
    	End Using
    End Function
    
    Public Function ByteArrayToException(bytes As Byte()) As Exception
    	If bytes Is Nothing OrElse bytes.Length = 0 Then
    		Return Nothing
    	End If
    	Using ms As New MemoryStream
    		Dim dcs As New DataContractSerializer(GetType(Exception))
    		ms.Write(bytes, 0, bytes.Length)
    		Return CType(dcs.ReadObject(ms), Exception)
    	End Using
    End Function
