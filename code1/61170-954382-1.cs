    <Extension()> Public Function Bytes(ByVal n As ULong,
                                        ByVal byteOrder As ByteOrder,
                                        Optional ByVal size As Integer = 8) As Byte()
        Dim data As New List(Of Byte)
        Do Until data.Count >= size
            data.Add(CByte(n And CULng(&HFF)))
            n >>= 8
        Loop
        Select Case byteOrder
            Case ByteOrder.BigEndian
                Return data.ToArray.reversed
            Case ByteOrder.LittleEndian
                Return data.ToArray
            Case Else
                Throw New ArgumentException("Unrecognized byte order.")
        End Select
    End Function
    <Extension()> Public Function ToULong(ByVal data As IEnumerable(Of Byte),
                                          ByVal byteOrder As ByteOrder) As ULong
        If data Is Nothing Then Throw New ArgumentNullException("data")
        Dim val As ULong
        Select Case byteOrder
            Case ByteOrder.LittleEndian
                data = data.Reverse
            Case ByteOrder.BigEndian
                'no change required
            Case Else
                Throw New ArgumentException("Unrecognized byte order.")
        End Select
        For Each b In data
            val <<= 8
            val = val Or b
        Next b
        Return val
    End Function
