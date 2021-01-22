    Public Function Object2Bytes(ByVal value As Object) As Byte()
    	Dim bytes As Byte()
    	Using ms As New MemoryStream
    		Dim ndcs As New NetDataContractSerializer()
    		ndcs.Serialize(ms, value)
    		bytes = ms.ToArray
    	End Using
    	Return bytes
    End Function
    Public Function Bytes2Object(ByVal bytes As Byte()) As Object
    	Using ms As New MemoryStream(bytes)
    		Dim ndcs As New NetDataContractSerializer
    		Return ndcs.Deserialize(ms)
    	End Using
    End Function
