    Private Shared ArrM As MethodInfo
    Private Shard Bits As FieldInfo
    Shared Sub New()
        ArrM = GetType(System.Numerics.BigInteger).GetMethod("ToUInt32Array", BindingFlags.NonPublic Or BindingFlags.Instance)
        Bits = GetType(System.Numerics.BigInteger).GetMember("_bits", BindingFlags.NonPublic Or BindingFlags.Instance)(0)
    End Sub
    <Extension()> _
    Public Function ToUInt32Array(ByVal Value As System.Numerics.BigInteger) As UInteger()
        Dim Result() As UInteger = ArrM.Invoke(Value, Nothing)
        If Result(Result.Length - 1) = 0 Then
            ReDim Preserve Result(Result.Length - 2)
        End If
        Return Result
    End Function
 
          
