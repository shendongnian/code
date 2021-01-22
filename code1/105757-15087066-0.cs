    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToSeqGuid(ByVal guid As Guid) As Guid
        Static lastTicks As Int64 = -1
        Dim ticks = DateTime.UtcNow.Ticks
        If ticks <= lastTicks Then
            ticks = lastTicks + 1
        End If
        lastTicks = ticks
        Dim ticksBytes = BitConverter.GetBytes(ticks)
        Array.Reverse(ticksBytes)
        Dim guidBytes = guid.ToByteArray()
        Array.Copy(ticksBytes, 0, guidBytes, 10, 6)
        Array.Copy(ticksBytes, 6, guidBytes, 8, 2)
        Return New Guid(guidBytes)
    End Function
