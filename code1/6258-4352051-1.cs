    Public Event MyEvent()
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If MyEventEvent IsNot Nothing Then
            For Each d In MyEventEvent.GetInvocationList //if this throws an exception, try using .ToArray
                RemoveHandler MyEvent, d
            Next
        End If
    End Sub
