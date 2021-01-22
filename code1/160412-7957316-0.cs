    Public Event Trigger As EventHandler
    Friend Sub OnTrigger(ByVal e As EventArgs)
        If TriggerEvent IsNot Nothing Then
            RaiseEvent Trigger(Me, e)
        End If
    End Sub
