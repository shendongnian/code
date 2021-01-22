    Private ReadOnly _toSeqGuidLock As New Object()
    ''' <summary>
    ''' Replaces the most significant eight bytes of the GUID (according to SQL Server ordering) with the current UTC-timestamp.
    ''' </summary>
    ''' <remarks>Thread-Safe</remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToSeqGuid(ByVal guid As Guid) As Guid
        Static lastTicks As Int64 = -1
        Dim ticks = DateTime.UtcNow.Ticks
        SyncLock _toSeqGuidLock
            If ticks <= lastTicks Then
                ticks = lastTicks + 1
            End If
            lastTicks = ticks
        End SyncLock
        Dim ticksBytes = BitConverter.GetBytes(ticks)
        Array.Reverse(ticksBytes)
        Dim guidBytes = guid.ToByteArray()
        Array.Copy(ticksBytes, 0, guidBytes, 10, 6)
        Array.Copy(ticksBytes, 6, guidBytes, 8, 2)
        Return New Guid(guidBytes)
    End Function
